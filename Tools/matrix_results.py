"""Check saved Unity results without starting another Editor."""
import argparse
from pathlib import Path
import xml.etree.ElementTree as ET


def wrap_player_suite(xml):
    """Restore the NUnit test-run envelope normally supplied by the Editor."""
    suite = ET.parse(xml).getroot()
    if suite.tag != "test-suite":
        raise ValueError(f"Unexpected standalone test result: {xml}")
    attributes = ("id", "testcasecount", "result", "total", "passed", "failed", "inconclusive",
                  "skipped", "asserts", "start-time", "end-time", "duration")
    run = ET.Element("test-run", {key: suite.attrib[key] for key in attributes if key in suite.attrib})
    run.append(suite)
    ET.ElementTree(run).write(xml, encoding="utf-8", xml_declaration=True)


def passed(xml):
    if not xml.is_file():
        raise ValueError(f"Missing test report: {xml}")
    run = ET.parse(xml).getroot()
    count = int(run.get("passed", 0))
    if run.get("result") != "Passed" or count < 1 or int(run.get("failed", 0)):
        raise ValueError(f"Failed or empty test run: {xml}")
    return count


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--results", type=Path, default=Path(__file__).resolve().parents[1] / "TestResults")
    parser.add_argument("--versions", nargs="+", default=["6000.7.0b10", "7000.0.0a21"])
    parser.add_argument("--profile", choices=["template", "minimal"], default="template")
    parser.add_argument("--stages", nargs="+", choices=["EditMode", "PlayMode", "Player", "Build"],
                        default=["EditMode", "PlayMode", "Player", "Build"])
    args = parser.parse_args()
    for version in args.versions:
        directory = args.results / version
        if args.profile == "minimal":
            directory /= "minimal"
        for stage in args.stages:
            if stage == "Build":
                log = directory / "Build.log"
                if not log.is_file() or "Build Successful" not in log.read_text(encoding="utf-8", errors="replace"):
                    raise SystemExit(f"Missing successful build report: {log}")
                print(version, stage, "exported")
            else:
                print(version, stage, passed(directory / (stage + ".xml")), "passed")


if __name__ == "__main__":
    main()
