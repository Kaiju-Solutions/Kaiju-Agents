"""Publish a validated source commit as an immutable package-root tag and release branch."""
import json
import os
from pathlib import Path
import re
import subprocess


def git(*args, **kwargs):
    return subprocess.run(["git", *args], text=True, check=True, capture_output=True, **kwargs).stdout.strip()


def publish(source, remote="origin"):
    package = "Packages/ca.kaijusolutions.agents"
    descriptor = json.loads(git("show", f"{source}:{package}/package.json"))
    version = descriptor["version"]
    if not re.fullmatch(r"[0-9]+\.[0-9]+\.[0-9]+(?:-[0-9A-Za-z.-]+)?", version):
        raise ValueError(f"Invalid package version {version}")
    tree = git("rev-parse", f"{source}:{package}")
    tag = "refs/tags/" + version
    branch = "refs/heads/release"
    existing = git("ls-remote", "--refs", remote, tag)
    if existing:
        git("fetch", "--no-tags", remote, tag)
        if git("rev-parse", "FETCH_HEAD^{tree}") != tree:
            raise ValueError(f"Published version {version} has different package contents")
        return version
    parent = git("ls-remote", "--refs", remote, branch)
    parents = []
    if parent:
        git("fetch", "--no-tags", remote, branch)
        parents = ["-p", git("rev-parse", "FETCH_HEAD")]
    commit = git("-c", "user.name=Kaiju package release", "-c", "user.email=release@users.noreply.github.com",
                 "commit-tree", tree, *parents, "-m", f"Kaiju Agents {version} from {source}")
    git("push", "--atomic", remote, f"{commit}:{branch}", f"{commit}:{tag}")
    return version


if __name__ == "__main__":
    version = publish(os.environ["GITHUB_SHA"])
    url = f"{os.environ['GITHUB_SERVER_URL']}/{os.environ['GITHUB_REPOSITORY']}.git#{version}"
    with Path(os.environ["GITHUB_OUTPUT"]).open("a") as output:
        print(f"version={version}\nurl={url}", file=output)
