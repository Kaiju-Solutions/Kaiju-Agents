"""Run the registered project Editor through Unity CLI, writing NUnit reports."""
from pathlib import Path
import os
import subprocess
from matrix_results import passed
from matrix_control import serial_matrix

root = Path(__file__).resolve().parents[1]
results = root / "TestResults" / "local-cli"
results.mkdir(parents=True, exist_ok=True)
with serial_matrix():
    for mode in ("EditMode", "PlayMode"):
        xml = results / (mode + ".xml")
        xml.unlink(missing_ok=True)
        subprocess.run(["unity", "test", str(root), "--mode", mode, "--filter", "KaijuSolutions.Agents.Tests",
                        "--output", str(xml), "--timeout", "900", "--non-interactive",
                        "--", "-nographics", "-silent-crashes", "-accept-apiupdate"],
                       stdin=subprocess.DEVNULL, env={**os.environ, "KAIJU_REQUIRE_SAMPLES": "1"}, check=True)
        passed(xml)
