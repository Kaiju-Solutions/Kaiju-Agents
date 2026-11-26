"""Run the warmed ECS steering benchmark in a headless standalone test player."""
import argparse
import hashlib
import json
import subprocess
import uuid
from pathlib import Path
import shutil
import sys
import tempfile

sys.path.insert(0, str(Path(__file__).resolve().parents[1]))
import unity_matrix

parser = argparse.ArgumentParser(description=__doc__)
parser.add_argument("--source", type=Path, default=unity_matrix.ROOT, help="Checkout to measure")
parser.add_argument("--versions", nargs="+", default=["6000.7.0b10", "7000.0.0a21"])
parser.add_argument("--baseline", action="store_true", help="Measure the pre-flight API only")
parser.add_argument("--full-matrix", action="store_true", help="Also run EditMode, PlayMode and sample builds")
parser.add_argument("--reference", action="store_true", help="Benchmark a flight-capable reference checkout")
args = parser.parse_args()
if args.baseline and args.reference:
    parser.error("Choose one reference mode")
source = args.source.resolve()
role = "baseline" if args.baseline or args.reference else "candidate"
run_id = uuid.uuid4().hex
destination = unity_matrix.ROOT / "TestResults/steering-benchmark" / role / run_id
destination.mkdir(parents=True)
with tempfile.TemporaryDirectory(prefix="KaijuBench-") as temp:
    root = Path(temp)
    digest = hashlib.sha256()
    for name in ("Assets", "Packages", "ProjectSettings"):
        shutil.copytree(source / name, root / name)
        for item in sorted((root / name).rglob("*")):
            if item.is_file():
                digest.update(item.relative_to(root).as_posix().encode() + b"\0")
                digest.update(hashlib.sha256(item.read_bytes()).digest())
    head = subprocess.run(["git", "-C", str(source), "rev-parse", "HEAD"], capture_output=True, text=True)
    revision = (head.stdout.strip() + ":" if head.returncode == 0 else "") + digest.hexdigest()
    tests = root / "Packages/ca.kaijusolutions.agents/Tests/Runtime"
    benchmark = Path(__file__).with_name("SteeringBenchmark.cs").read_text()
    (tests / "SteeringBenchmark.cs").write_text(("" if args.baseline else "#define KAIJU_FLIGHT\n") + benchmark)
    hybrid = Path(__file__).with_name("HybridBenchmark.cs")
    if not args.reference and not args.baseline and hybrid.is_file():
        shutil.copy2(hybrid, tests / hybrid.name)
        # Instrument the isolated fixture build so library users pay no timing overhead.
        simulation = tests.parents[1] / "Runtime/KaijuSimulation.cs"
        code = simulation.read_text()
        code = code.replace("            CompleteDependency();", """            long syncStart = System.Diagnostics.Stopwatch.GetTimestamp();
            CompleteDependency();
            BenchmarkSync.Ticks += System.Diagnostics.Stopwatch.GetTimestamp() - syncStart;""")
        bridge = "_bridges.ToComponentDataArray<KaijuAgentBridge>(Allocator.Temp);"
        code = code.replace(bridge, bridge + "\n            BenchmarkSync.Bytes += links.Length * Unity.Collections.LowLevel.Unsafe.UnsafeUtility.SizeOf<KaijuAgentBridge>();")
        code += "\nnamespace KaijuSolutions.Agents { public static class BenchmarkSync { public static long Ticks, Bytes; } }\n"
        simulation.write_text(code)
    unity_matrix.ROOT = root
    stages = ["EditMode", "PlayMode", "Player", "Build"] if args.full_matrix else ["Player"]
    sys.argv = [sys.argv[0], "--versions", *args.versions, "--stages", *stages, "--player-runs", "3"]
    try:
        unity_matrix.main()
    finally:
        if (root / "TestResults").exists():
            shutil.copytree(root / "TestResults", destination, dirs_exist_ok=True)

    manifest = {"run_id": run_id, "source_revision": revision, "role": role, "versions": args.versions,
                "flight": not args.baseline, "logs": {}}
    for version in args.versions:
        for suffix in ("", "-2", "-3"):
            log = destination / version / f"Player-runtime{suffix}.log"
            manifest["logs"][log.relative_to(destination).as_posix()] = hashlib.sha256(log.read_bytes()).hexdigest()
    pending = destination / "complete.tmp"
    pending.write_text(json.dumps(manifest, indent=2))
    pending.replace(destination / "complete.json")
    print(f"Completed {role} run {run_id}", flush=True)
