"""Exercise the matrix control flow without an Editor installation."""
import json
import plistlib
from pathlib import Path
from types import SimpleNamespace
import tempfile
import unittest
import xml.etree.ElementTree as ET
from unittest.mock import patch

import unity_matrix


class ExecutionTests(unittest.TestCase):
    def test_each_stage_uses_an_isolated_project_and_reports_results(self):
        with tempfile.TemporaryDirectory() as temp:
            root = Path(temp)
            for name in ("Assets", "ProjectSettings", "Packages"):
                (root / name).mkdir()
            manifest = root / "Packages/manifest.json"
            manifest.write_text('{"dependencies":{"com.unity.ml-agents":"test"}}')
            seen = []
            def execute(command, **kwargs):
                self.assertIn("-batchmode", command)
                self.assertIn("-nographics", command)
                self.assertEqual(kwargs["stdin"], unity_matrix.subprocess.DEVNULL)
                environment = kwargs.get("env", {})
                if "KAIJU_TEST_PLAYER_REPORT" in environment:
                    self.assertTrue(Path(command[0]).is_file())
                    seen.append("Player run")
                    Path(environment["KAIJU_TEST_PLAYER_REPORT"]).write_text('<test-suite result="Passed" passed="1"/>')
                    return SimpleNamespace(returncode=0)
                project = Path(command[command.index("-projectPath") + 1])
                self.assertNotEqual(root, project)
                self.assertNotIn("com.unity.ml-agents", json.loads((project / "Packages/manifest.json").read_text())["dependencies"])
                if "KAIJU_TEST_PLAYER_PATH" in environment:
                    seen.append("Player build")
                    self.assertIn("-doNotReportTestResultsBackToEditor", command)
                    binary = Path(environment["KAIJU_TEST_PLAYER_PATH"])
                    if unity_matrix.sys.platform == "darwin":
                        contents = binary / "Contents"
                        binary = contents / "MacOS" / "Standalone"
                        binary.parent.mkdir(parents=True)
                        (contents / "Info.plist").write_bytes(plistlib.dumps({"CFBundleExecutable": binary.name}))
                    binary.touch()
                elif "-runTests" in command:
                    seen.append(command[command.index("-testPlatform") + 1])
                    Path(command[command.index("-testResults") + 1]).write_text('<test-run result="Passed" passed="1"/>')
                else:
                    seen.append("Build")
                    Path(kwargs["env"]["KAIJU_BUILD_PATH"]).touch()
                return SimpleNamespace(returncode=0)
            with patch.object(unity_matrix, "ROOT", root), patch.object(unity_matrix, "check_stop"), \
                    patch.object(unity_matrix, "editor_for", return_value=root / "Editor"), \
                    patch.object(unity_matrix.subprocess, "run", side_effect=execute):
                unity_matrix.validate(root, "6000.7.0b10", ["EditMode", "PlayMode", "Player", "Build"], "minimal", player_runs=2)
            self.assertEqual(seen, ["EditMode", "PlayMode", "Player build", "Player run", "Player run", "Build"])
            self.assertTrue((root / "TestResults/6000.7.0b10/minimal/Player-2.xml").is_file())
            report = ET.parse(root / "TestResults/6000.7.0b10/minimal/Player.xml").getroot()
            self.assertEqual(report.tag, "test-run")
            self.assertEqual(report.find("test-suite").get("passed"), "1")
            self.assertIn("com.unity.ml-agents", json.loads(manifest.read_text())["dependencies"])


if __name__ == "__main__":
    unittest.main()
