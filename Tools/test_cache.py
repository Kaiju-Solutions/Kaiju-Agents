"""Verify reuse is isolated by checkout, Editor and package configuration."""
from pathlib import Path
import tempfile
import unittest
from unity_cache import workspace


class CacheTests(unittest.TestCase):
    def test_only_library_is_reused(self):
        with tempfile.TemporaryDirectory() as temp:
            root = Path(temp)
            def open_project(version="6000.7.0b10", profile="template", repo="checkout"):
                return workspace(root / repo, version, profile, True, root)
            with open_project() as first:
                (first / "Library").mkdir()
                (first / "Library/imported").touch()
                (first / "stale-source").touch()
            with open_project() as second:
                self.assertEqual(first, second)
                self.assertTrue((second / "Library/imported").is_file())
                self.assertFalse((second / "stale-source").exists())
            for args in ({"version": "7000.0.0a21"}, {"profile": "minimal"}, {"repo": "other"}):
                with open_project(**args) as isolated:
                    self.assertFalse((isolated / "Library").exists())


if __name__ == "__main__":
    unittest.main()
