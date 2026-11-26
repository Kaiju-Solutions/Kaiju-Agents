"""Serialize matrix invocations on this host, and support stopping between Editor stages."""
from contextlib import contextmanager
from pathlib import Path
import os
import tempfile

LOCK = Path(tempfile.gettempdir()) / "kaiju-agents-unity-matrix.lock"
STOP = LOCK.with_suffix(".stop")


@contextmanager
def serial_matrix():
    with LOCK.open("a+b") as handle:
        if handle.tell() == 0:
            handle.write(b"1")
            handle.flush()
        handle.seek(0)
        try:
            if os.name == "nt":
                import msvcrt
                msvcrt.locking(handle.fileno(), msvcrt.LK_NBLCK, 1)
            else:
                import fcntl
                fcntl.flock(handle.fileno(), fcntl.LOCK_EX | fcntl.LOCK_NB)
        except OSError:
            raise SystemExit("Another Kaiju Agents matrix is running on this host.")
        STOP.unlink(missing_ok=True)
        try:
            yield
        finally:
            STOP.unlink(missing_ok=True)
            # Closing the handle releases the OS lock, including after a crash.


def check_stop():
    if STOP.exists():
        raise SystemExit("Matrix stopped after the last completed Editor stage.")


if __name__ == "__main__":
    STOP.touch()
    print("A running matrix will stop before starting its next Editor stage.")
