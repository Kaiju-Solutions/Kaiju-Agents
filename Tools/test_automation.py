"""Regression tests for the matrix result checks and host-level serialization."""
from pathlib import Path
import tempfile
import unittest
from unittest.mock import patch

import matrix_control
from matrix_results import passed


class MatrixTests(unittest.TestCase):
    def test_test_reports_must_contain_a_passing_result(self):
        with tempfile.TemporaryDirectory() as temp:
            xml = Path(temp) / "tests.xml"
            with self.assertRaises(ValueError):
                passed(xml)
            for result, successes, failures in (("Passed", 0, 0), ("Failed", 1, 1), ("Passed", 1, 1)):
                xml.write_text(f'<test-run result="{result}" passed="{successes}" failed="{failures}"/>')
                with self.assertRaises(ValueError):
                    passed(xml)
            xml.write_text('<test-run result="Passed" passed="4" failed="0"/>')
            self.assertEqual(passed(xml), 4)

    def test_lock_excludes_another_run_and_resets_stop_requests(self):
        with tempfile.TemporaryDirectory() as temp:
            root = Path(temp)
            with patch.object(matrix_control, "LOCK", root / "lock"), patch.object(matrix_control, "STOP", root / "stop"):
                with matrix_control.serial_matrix():
                    with self.assertRaises(SystemExit):
                        with matrix_control.serial_matrix():
                            self.fail("A second matrix acquired the lock.")
                    matrix_control.STOP.touch()
                    with self.assertRaises(SystemExit):
                        matrix_control.check_stop()
                with matrix_control.serial_matrix():
                    matrix_control.check_stop()


if __name__ == "__main__":
    unittest.main()
