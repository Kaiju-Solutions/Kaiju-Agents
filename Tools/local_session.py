"""Run package tests through the Pipeline of an already-open Unity project."""
import argparse
import json
from pathlib import Path
import subprocess
import time
from prepare import check_samples

PACKAGE = "ca.kaijusolutions.agents.tests."


def run(project, mode):
    args = ["unity", "command", "--non-interactive", "--project-path", str(project), "--format", "json"]
    assembly = PACKAGE + ("editor" if mode == "editor" else "runtime")
    subprocess.run(args + ["test", "run", "--mode", mode, "--filter-type", "Assembly",
                           "--filter", assembly, "--async-tests", "true"], check=True, timeout=120)
    deadline = time.monotonic() + 900
    while time.monotonic() < deadline:
        time.sleep(2)
        poll = subprocess.run(args + ["test", "status", "--detail", "failures"],
                              capture_output=True, text=True, timeout=60)
        if poll.returncode == 12:  # Domain reload can temporarily disconnect Pipeline.
            continue
        if poll.returncode:
            raise SystemExit(poll.stderr or poll.stdout)
        result = json.loads(poll.stdout)
        if result.get("status") == "completed":
            summary = result["summary"]
            if summary["passed"] < 1 or summary["failed"]:
                raise SystemExit(result)
            print(assembly, summary)
            return
        if result.get("status") in ("no_tests", "cancelled", "error"):
            raise SystemExit(result)
    raise SystemExit("Timed out waiting for Pipeline test status")


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--project", type=Path, default=Path(__file__).resolve().parents[1])
    parser.add_argument("--modes", nargs="+", choices=["editor", "playmode"], default=["editor", "playmode"])
    options = parser.parse_args()
    if options.project.resolve() == Path(__file__).resolve().parents[1]:
        check_samples()
    for mode in options.modes:
        run(options.project.resolve(), mode)
