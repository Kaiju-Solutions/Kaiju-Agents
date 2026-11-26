"""Exercise publication against a local remote and reject mixed benchmark artifacts."""
import hashlib
import json
import os
from pathlib import Path
import subprocess
import tempfile
import unittest
from Benchmarks.report import completed
from publish_package import git, publish


class ReleaseAuditTests(unittest.TestCase):
    def test_immutable_root_tag_and_retry(self):
        with tempfile.TemporaryDirectory() as temp:
            root = Path(temp)
            remote = root / "origin.git"
            subprocess.run(["git", "init", "--bare", str(remote)], check=True, capture_output=True)
            repo = root / "source"
            repo.mkdir()
            previous = os.getcwd()
            os.chdir(repo)
            try:
                git("init")
                git("remote", "add", "origin", str(remote))
                package = Path("Packages/ca.kaijusolutions.agents")
                package.mkdir(parents=True)
                (package / "package.json").write_text('{"version":"2.0.0"}')
                git("add", ".")
                def commit():
                    git("-c", "user.name=test", "-c", "user.email=test@example.com", "commit", "-am", "test")
                    return git("rev-parse", "HEAD")
                source = commit()
                self.assertEqual(publish(source), "2.0.0")
                self.assertEqual(publish(source), "2.0.0")
                git("fetch", "--tags", "origin")
                self.assertEqual(git("ls-tree", "--name-only", "2.0.0"), "package.json")
                before = git("ls-remote", "--refs", "origin")
                (package / "package.json").write_text('{"version":"2.0.0","changed":true}')
                with self.assertRaises(ValueError):
                    publish(commit())
                self.assertEqual(git("ls-remote", "--refs", "origin"), before)
            finally:
                os.chdir(previous)

    def test_report_uses_only_sealed_logs_from_one_run(self):
        with tempfile.TemporaryDirectory() as temp:
            role = Path(temp) / "candidate"
            run_id = "a" * 32
            run = role / run_id
            editor = run / "v"
            editor.mkdir(parents=True)
            (role / "interrupted").mkdir()
            logs = {}
            for suffix in ("", "-2", "-3"):
                log = editor / f"Player-runtime{suffix}.log"
                log.write_bytes(b"good")
                logs["v/" + log.name] = hashlib.sha256(log.read_bytes()).hexdigest()
            (run / "complete.json").write_text(json.dumps({"role":"candidate","run_id":run_id,"versions":["v"],
                                                            "source_revision":"abc","logs":logs}))
            self.assertEqual(completed(role, None, ["v"])[0], run)
            with self.assertRaises(ValueError):
                completed(role, run_id, ["v"], expected_revision="other")
            log.write_bytes(b"different run")
            with self.assertRaises(ValueError):
                completed(role, run_id, ["v"])
