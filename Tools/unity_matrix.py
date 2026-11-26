"""Run real Editor and player tests serially against isolated copies of this checkout."""
import argparse
import json
import os
from pathlib import Path
import plistlib
import re
import shutil
import subprocess
import sys
from unity_cache import workspace
from matrix_results import passed, wrap_player_suite
from matrix_control import serial_matrix, check_stop

ROOT = Path(__file__).resolve().parents[1]
PACKAGE = "ca.kaijusolutions.agents"


def editor_for(hub, version):
    base = hub / version
    candidates = [base / "Editor" / "Unity.exe", base / "Editor" / "Unity", base / "Unity",
                  base / "Unity.app" / "Contents" / "MacOS" / "Unity"]
    return next((p for p in candidates if p.is_file()), None)


def validate(hub, version, stages, profile, reuse_cache=False, player_runs=1):
    check_stop()
    editor = editor_for(hub, version)
    if not editor:
        raise SystemExit(f"Install Unity {version} in {hub}")
    output = ROOT / "TestResults" / version
    if profile == "minimal":
        output = output / "minimal"
    output.mkdir(parents=True, exist_ok=True)
    with workspace(ROOT, version, profile, reuse_cache) as project:
        for name in ("Packages", "Assets", "ProjectSettings"):
            shutil.copytree(ROOT / name, project / name)
        (project / "ProjectSettings/ProjectVersion.txt").write_text(f"m_EditorVersion: {version}\n")
        # Built-in package versions track the Editor line.
        resources = editor.parent / "Data/Resources" if sys.platform != "darwin" else editor.parents[1] / "Resources"
        builtins = resources / "PackageManager/BuiltInPackages"
        manifest = project / "Packages/manifest.json"
        data = json.loads(manifest.read_text())
        if profile == "minimal":
            for optional in ("com.unity.ml-agents",):
                data["dependencies"].pop(optional, None)
        for name in data["dependencies"]:
            descriptor = builtins / name / "package.json"
            if descriptor.exists():
                data["dependencies"][name] = json.loads(descriptor.read_text())["version"]
        manifest.write_text(json.dumps(data, indent=2))
        # Inference fixtures use local models. Suppress the Academy's default Editor trainer connection.
        headless = ["-batchmode", "-nographics", "-silent-crashes", "--mlagents-port", "0"]
        filename = {"win32": "KaijuAgents.exe", "linux": "KaijuAgents", "darwin": "KaijuAgents.app"}[sys.platform]
        launch = {"stdin": subprocess.DEVNULL, "creationflags": getattr(subprocess, "CREATE_NO_WINDOW", 0)}
        for stage in stages:
            check_stop()
            log = output / (stage + ".log")
            target = {"win32": "StandaloneWindows64", "linux": "StandaloneLinux64", "darwin": "StandaloneOSX"}[sys.platform]
            platform = target if stage == "Player" else stage
            if stage == "Build":
                destination = project / "Build" / filename
                destination.parent.mkdir(exist_ok=True)
                command = [str(editor), *headless, "-accept-apiupdate", "-quit", "-projectPath", str(project),
                           "-logFile", str(log), "-executeMethod", "KaijuSolutions.Agents.Validation.KaijuBuildValidation.BuildPlayer"]
                print(f"{version} sample player | {log}", flush=True)
                subprocess.run(command, **launch, env={**os.environ, "KAIJU_BUILD_PATH": str(destination)}, timeout=3600, check=True)
                if not destination.exists():
                    raise SystemExit(f"No player exported. See {log}")
                continue
            xml = output / (stage + ".xml")
            xml.unlink(missing_ok=True)
            command = [str(editor), *headless, "-accept-apiupdate", "-projectPath", str(project),
                       "-logFile", str(log), "-runTests", "-testPlatform", platform,
                       "-assemblyNames", PACKAGE + ".tests." + ("editor" if stage == "EditMode" else "runtime"),
                       "-testResults", str(xml)]
            print(f"{version} {stage} | {log}", flush=True)
            if stage == "Player":
                player = project / "TestPlayer" / filename
                player.parent.mkdir(exist_ok=True)
                subprocess.run(command + ["-doNotReportTestResultsBackToEditor"], **launch,
                               env={**os.environ, "KAIJU_TEST_PLAYER_PATH": str(player)}, timeout=3600, check=True)
                if not player.exists():
                    raise SystemExit(f"Unity did not export the test player. See {log}")
                if sys.platform == "darwin":
                    contents = player / "Contents"
                    with (contents / "Info.plist").open("rb") as info:
                        player = contents / "MacOS" / plistlib.load(info)["CFBundleExecutable"]
                for run in range(1, player_runs + 1):
                    check_stop()
                    suffix = "" if run == 1 else f"-{run}"
                    xml = output / f"Player{suffix}.xml"
                    xml.unlink(missing_ok=True)
                    log = output / f"Player-runtime{suffix}.log"
                    result = subprocess.run([str(player), *headless, "-logFile", str(log)], **launch,
                                            env={**os.environ, "KAIJU_REQUIRE_SAMPLES": "1", "KAIJU_TEST_PLAYER_REPORT": str(xml)}, timeout=900)
                    if xml.is_file():
                        wrap_player_suite(xml)
                    if result.returncode or not xml.exists():
                        raise SystemExit(f"Test player failed (exit {result.returncode}). See {log}")
                    passed(xml)
                continue
            result = subprocess.run(command, **launch, env={**os.environ, "KAIJU_REQUIRE_SAMPLES": "1"}, timeout=3600)
            if result.returncode or not xml.exists():
                raise SystemExit(f"{stage} failed (exit {result.returncode}). See {log}")
            passed(xml)


def main():
    default = {"win32": "C:/Program Files/Unity/Hub/Editor", "linux": str(Path.home() / "Unity/Hub/Editor"),
               "darwin": "/Applications/Unity/Hub/Editor"}[sys.platform]
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--hub", type=Path, default=os.environ.get("UNITY_HUB_EDITORS", default))
    parser.add_argument("--versions", nargs="+", default=["6000.7.0b10", "7000.0.0a21"])
    parser.add_argument("--stages", nargs="+", choices=["EditMode", "PlayMode", "Player", "Build"],
                        default=["EditMode", "PlayMode", "Player", "Build"])
    parser.add_argument("--profile", choices=["template", "minimal"], default="template")
    parser.add_argument("--reuse-cache", action="store_true", help="Retain the generated Unity Library between local runs")
    parser.add_argument("--player-runs", type=int, default=1, help="Independent launches of each built test player")
    args = parser.parse_args()
    if args.player_runs < 1:
        parser.error("--player-runs must be positive")
    with serial_matrix():
        run_versions(args)


def run_versions(args):
    for version in args.versions:
        if not re.fullmatch(r"(6000\.7|7000\.\d+)\.\d+[abfp]\d+", version):
            raise SystemExit(f"Unsupported Editor version {version}")
        validate(args.hub, version, args.stages, args.profile, args.reuse_cache, args.player_runs)


if __name__ == "__main__":
    main()
