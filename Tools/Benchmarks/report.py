"""Summarize standalone benchmark logs and compare independently launched ground runs."""
import argparse
import hashlib
import json
import re
from pathlib import Path
from statistics import median


def completed(folder, run_id, versions, expected_revision=None):
    if run_id and not re.fullmatch(r"[0-9a-f]{32}", run_id):
        raise ValueError("Invalid benchmark run ID")
    manifests = [folder / run_id / "complete.json"] if run_id else sorted(folder.glob("*/complete.json"), key=lambda path: path.stat().st_mtime, reverse=True)
    for path in manifests:
        data = json.loads(path.read_text())
        if not set(versions).issubset(data["versions"]):
            continue
        if expected_revision and data["source_revision"] != expected_revision:
            continue
        if data["role"] != folder.name or data["run_id"] != path.parent.name or not data["source_revision"]:
            raise ValueError(f"Invalid benchmark manifest {path}")
        for version in versions:
            for suffix in ("", "-2", "-3"):
                key = f"{version}/Player-runtime{suffix}.log"
                if hashlib.sha256((path.parent / key).read_bytes()).hexdigest() != data["logs"].get(key):
                    raise ValueError(f"Log does not match completed run: {key}")
        return path.parent, data
    raise ValueError(f"No completed {folder.name} run for {versions}")


def launches(folder):
    result = []
    for log in sorted(folder.glob("Player-runtime*.log")):
        rounds = {}
        queries = {}
        for line in log.read_text(encoding="utf-8", errors="replace").splitlines():
            if line.startswith("KAIJU_PERF "):
                values = dict(field.split("=") for field in line.split()[1:])
                rounds.setdefault(int(values.pop("flight")), []).append({key: float(value) for key, value in values.items()})
            elif line.startswith("KAIJU_QUERY "):
                queries = dict(field.split("=") for field in line.split()[1:])
        if not rounds or not queries:
            raise ValueError(f"Incomplete performance log: {log}")
        result.append((rounds, queries))
    if len(result) != 3:
        raise ValueError(f"Expected three standalone player launches under {folder}")
    return result


def summarize(folder, populations, label):
    runs = launches(folder)
    timings = {}
    for population in populations:
        rounds = [run[0][population] for run in runs]
        if any(len(series) != 5 for series in rounds):
            raise ValueError(f"Expected five rounds per player for {population}% flight: {folder}")
        def medians(key):
            return [median(row[key] for row in series) for series in rounds]
        times = medians("step_us")
        timings[population] = times
        allocations = max(row["gc_bytes"] for series in rounds for row in series)
        if allocations:
            raise ValueError(f"Steady-state managed allocation: {folder}, {population}% flight")
        print(f"| {folder.name} | {label} | {population}% | {median(times):.1f} "
              f"({min(times):.1f}-{max(times):.1f}) | {median(medians('wait_us')):.1f} | "
              f"{median(medians('cpu_us')):.1f} | {int(median(medians('chunks')))} | "
              f"{median(medians('steering_bytes')) / median(medians('agents')):.0f} | {int(allocations)} |")
    return timings, {key: median(float(query[key]) for _, query in runs) for key in ("path_us", "spherecast_us")}


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--results", type=Path, default=Path(__file__).resolve().parents[2] / "TestResults/steering-benchmark")
    parser.add_argument("--versions", nargs="+", default=["6000.7.0b10", "7000.0.0a21"])
    parser.add_argument("--baseline-run")
    parser.add_argument("--candidate-run")
    parser.add_argument("--baseline-revision", help="Require this exact source revision/digest")
    parser.add_argument("--candidate-revision", help="Require this exact source revision/digest")
    args = parser.parse_args()
    baseline, old = completed(args.results / "baseline", args.baseline_run, args.versions, args.baseline_revision)
    candidate, new = completed(args.results / "candidate", args.candidate_run, args.versions, args.candidate_revision)
    for run in (old, new):
        print(f"{run['role']} {run['run_id']} source {run['source_revision']}")
    print("| Editor | Build | Flyers | Step us (launch range) | Wait us | Process CPU us | Chunks | Steering B/agent | Managed B/round |")
    print("|---|---|---:|---:|---:|---:|---:|---:|---:|")
    comparisons = []
    for version in args.versions:
        base, base_query = summarize(baseline / version, [0, 50, 100] if old["flight"] else [0], "reference")
        current, current_query = summarize(candidate / version, [0, 50, 100], "candidate")
        comparisons.append((version, base[0], current[0], base_query, current_query))
    for version, base, current, old_query, new_query in comparisons:
        print(f"\n{version} ground median change: {(median(current)/median(base)-1)*100:+.1f}%. "
              f"Path query {old_query['path_us']:.2f} to {new_query['path_us']:.2f} us. "
              f"Sphere cast {old_query['spherecast_us']:.2f} to {new_query['spherecast_us']:.2f} us.")
        hybrid = {}
        for log in sorted((candidate / version).glob("Player-runtime*.log")):
            for line in log.read_text(encoding="utf-8", errors="replace").splitlines():
                if not line.startswith("KAIJU_HYBRID "):
                    continue
                row = dict(token.split("=") for token in line.split()[1:])
                key = tuple(row.pop(field) for field in ("bridge", "vision", "brains", "nearby"))
                hybrid.setdefault(key, []).append(row)
        for key, rows in hybrid.items():
            if len(rows) != 3:
                raise ValueError(f"Incomplete hybrid data: {version} {key}")
            print("Hybrid", *key, *(f"{field}={median(float(r[field]) for r in rows):.1f}" for field in rows[0]))
