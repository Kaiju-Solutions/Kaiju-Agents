"""Synchronize repository guidance and provider-specific consumer skill directories."""
import argparse
import json
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
PACKAGE = ROOT / "Packages/ca.kaijusolutions.agents"
PROVIDERS = {"codex": (".agents", "AGENTS.md"), "claude": (".claude", "CLAUDE.md"),
             "gemini": (".gemini", "GEMINI.md"), "qwen": (".qwen", "QWEN.md")}


def sync(check=False):
    def mirror(source, dest):
        if dest.exists() and dest.read_bytes() == source.read_bytes():
            return
        if check:
            raise SystemExit(f"Guidance differs: {dest}")
        dest.parent.mkdir(parents=True, exist_ok=True)
        dest.write_bytes(source.read_bytes())

    manifest = PACKAGE / "Skills~/files.json"
    canonical = PACKAGE / "Skills~/codex"
    files = sorted(p.relative_to(canonical).as_posix() for p in canonical.rglob("*") if p.is_file())
    previous = json.loads(manifest.read_text()) if manifest.exists() else []
    obsolete = set(previous).difference(files)
    for provider, (directory, instruction) in PROVIDERS.items():
        for root in (ROOT, PACKAGE):
            mirror(root / "AGENTS.md", root / instruction)
        mirror_root = PACKAGE / "Skills~" / provider
        for managed in (mirror_root, ROOT / directory / "skills"):
            for relative in obsolete:
                old = managed / relative
                if not old.resolve().is_relative_to(managed.resolve()):
                    raise ValueError("Unexpected skill manifest path")
                if old.is_file():
                    if check:
                        raise SystemExit(f"Obsolete mirrored skill file: {old}")
                    old.unlink()
        for source in sorted(p for p in canonical.rglob("*") if p.is_file()):
            relative = source.relative_to(PACKAGE / "Skills~/codex")
            mirror(source, PACKAGE / "Skills~" / provider / relative)
            mirror(source, ROOT / directory / "skills" / relative)

    content = json.dumps(files, indent=2) + "\n"
    if check and (not manifest.exists() or manifest.read_text() != content):
        raise SystemExit("Refresh package skill file manifest")
    if not check:
        manifest.write_text(content)


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--check", action="store_true")
    sync(parser.parse_args().check)
