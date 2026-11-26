"""Resolve a released Git URL in a clean Unity consumer and verify its locked package."""
import argparse
from contextlib import chdir
import json
import os
from pathlib import Path
import subprocess
import shutil
import sys
import tempfile
from matrix_control import serial_matrix
from publish_package import git, publish
from unity_matrix import ROOT, PACKAGE, editor_for


def smoke(version, url, hub, environment=None):
    editor = editor_for(hub, version)
    if not editor:
        raise ValueError(f"Missing Editor {version}")
    expected = json.loads((ROOT / "Packages" / PACKAGE / "package.json").read_text())["version"]
    base, separator, tag = url.rpartition("#")
    if not separator or tag != expected:
        raise ValueError(f"Expected tagged package URL for {expected}")
    ref = "refs/tags/" + tag
    resolved = subprocess.run(["git", "ls-remote", "--exit-code", base, ref, ref + "^{}"],
                              capture_output=True, text=True, check=True, timeout=120, env=environment)
    hashes = {name: commit for commit, name in (line.split() for line in resolved.stdout.splitlines())}
    expected_commit = hashes.get(ref + "^{}", hashes[ref])
    log = ROOT / "TestResults" / version / "Consumer-install.log"
    log.parent.mkdir(parents=True, exist_ok=True)
    with tempfile.TemporaryDirectory(prefix="KaijuConsumer-") as tmp:
        project = Path(tmp)
        for name in ("Assets", "Packages", "ProjectSettings"):
            (project / name).mkdir()
        (project / "Packages/manifest.json").write_text(json.dumps({"dependencies": {PACKAGE: url}}))
        (project / "ProjectSettings/ProjectVersion.txt").write_text(f"m_EditorVersion: {version}\n")
        scripts = project / "Assets/Editor"
        scripts.mkdir()
        shutil.copy2(ROOT / "Tools/ConsumerSmoke.cs", scripts)
        subprocess.run([str(editor), "-batchmode", "-nographics", "-silent-crashes", "-quit", "-projectPath", tmp,
                        "-executeMethod", "ConsumerSmoke.Verify", "-logFile", str(log)], stdin=subprocess.DEVNULL,
                       creationflags=getattr(subprocess, "CREATE_NO_WINDOW", 0), env=environment, check=True, timeout=1800)
        if "KAIJU_CONSUMER_VERIFIED" not in log.read_text(encoding="utf-8", errors="replace"):
            raise ValueError(f"Consumer verification did not complete: {log}")
        locked = json.loads((project / "Packages/packages-lock.json").read_text())["dependencies"][PACKAGE]
        if locked["source"] != "git" or locked["version"] != url or locked.get("hash") != expected_commit:
            raise ValueError(f"Unexpected resolved package: {locked}")
        cached = list((project / "Library/PackageCache").glob(PACKAGE + "@*/package.json"))
        if len(cached) != 1 or json.loads(cached[0].read_text())["version"] != expected:
            raise ValueError(f"Expected package version {expected} in consumer")
        if not (project / "Library/ScriptAssemblies" / (PACKAGE + ".dll")).is_file():
            raise ValueError("Consumer did not compile the runtime assembly")
        print(f"Installed {PACKAGE} {expected} from {url} at {locked['hash']}")


def rehearse(versions, hub):
    with tempfile.TemporaryDirectory(prefix="KaijuRelease-") as temporary:
        root = Path(temporary)
        repo = root / "source"
        remote = root / "release.git"
        shutil.copytree(ROOT / "Packages" / PACKAGE, repo / "Packages" / PACKAGE)
        with chdir(repo):
            git("init", "--bare", str(remote))
            git("init")
            git("remote", "add", "origin", str(remote))
            git("add", "Packages")
            git("-c", "user.name=Package validation", "-c", "user.email=validation@example.com",
                "commit", "-m", "Local release rehearsal")
            tag = publish(git("rev-parse", "HEAD"))
        base = "https://github.com/Kaiju-Solutions/Kaiju-Agents.git"
        environment = os.environ.copy()
        environment["UPM_CACHE_ROOT"] = str(root / "upm-cache")
        index = int(environment.get("GIT_CONFIG_COUNT", 0))
        environment.update({"GIT_CONFIG_COUNT": str(index + 1),
                            f"GIT_CONFIG_KEY_{index}": f"url.{remote.as_uri()}.insteadOf",
                            f"GIT_CONFIG_VALUE_{index}": base})
        for version in versions:
            smoke(version, base + "#" + tag, hub, environment)


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--version", nargs="+", required=True)
    parser.add_argument("--local-release", action="store_true", help="Rehearse publication against a temporary local Git remote")
    parser.add_argument("--url", default=os.environ.get("KAIJU_INSTALL_URL"))
    default = {"win32": "C:/Program Files/Unity/Hub/Editor", "linux": str(Path.home() / "Unity/Hub/Editor"),
               "darwin": "/Applications/Unity/Hub/Editor"}[sys.platform]
    parser.add_argument("--hub", type=Path, default=os.environ.get("UNITY_HUB_EDITORS", default))
    args = parser.parse_args()
    if bool(args.url) == args.local_release:
        parser.error("Select a Git URL or --local-release")
    with serial_matrix():
        if args.local_release:
            rehearse(args.version, args.hub)
        else:
            for version in args.version:
                smoke(version, args.url, args.hub)
