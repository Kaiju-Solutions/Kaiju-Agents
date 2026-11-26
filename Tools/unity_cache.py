"""Retain only Unity's generated Library between otherwise fresh matrix projects."""
from contextlib import contextmanager
from hashlib import sha256
from pathlib import Path
import tempfile
import shutil


@contextmanager
def workspace(source, version, profile, reuse=False, temp_root=None):
    base = Path(temp_root or tempfile.gettempdir()).resolve()
    key = sha256(str(source.resolve()).encode()).hexdigest()[:16]
    bucket = base / "KaijuAgents-Libraries" / key / version / profile
    if not reuse:
        with tempfile.TemporaryDirectory(prefix="KaijuAgents-", dir=base) as temp:
            yield Path(temp)
        return

    # Bee stores absolute paths in its build graphs. Keep the generated Library
    # and its owning project at a stable path across Editor invocations.
    project = bucket / "project"
    if project.resolve() != project or not project.is_relative_to(base / "KaijuAgents-Libraries"):
        raise ValueError("Unexpected Unity Library cache path")
    project.mkdir(parents=True, exist_ok=True)
    if (project / "Library").is_symlink():
        raise ValueError("Unexpected symbolic link for cached Library")
    # Refresh sources and clear products from an interrupted run before copying.
    for entry in project.iterdir():
        if entry.name == "Library":
            continue
        if entry.is_symlink() or entry.is_file():
            entry.unlink()
        else:
            shutil.rmtree(entry)
    yield project
