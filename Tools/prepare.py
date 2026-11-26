"""Refresh or verify generated material before publishing the UPM package."""
import argparse
import json
from pathlib import Path


def check_samples():
    root = Path(__file__).resolve().parents[1]
    package = root / "Packages/ca.kaijusolutions.agents"
    descriptor = json.loads((package / "package.json").read_text())
    version = descriptor["version"]
    imported = root / "Assets/Samples" / descriptor["displayName"] / version
    if f"  bundleVersion: {version}" not in (root / "ProjectSettings/ProjectSettings.asset").read_text().splitlines():
        raise SystemExit("Template build version differs from package version")
    for sample in descriptor["samples"]:
        source = package / sample["path"]
        target = imported / sample["displayName"]
        for item in source.rglob("*"):
            if item.is_file():
                copy = target / item.relative_to(source)
                if not copy.is_file() or item.read_bytes() != copy.read_bytes():
                    raise SystemExit(f"Imported sample differs: {copy}")


if __name__ == "__main__":
    from documentation import build
    from guidance import sync
    from documentation_links import check as check_links

    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--check", action="store_true")
    check = parser.parse_args().check
    check_samples()
    sync(check)
    build(check)
    check_links()
