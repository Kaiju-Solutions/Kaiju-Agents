"""Check the source tree's space indentation and left-aligned preprocessor directives."""
import argparse
from pathlib import Path
import re

root = Path(__file__).resolve().parents[1]
parser = argparse.ArgumentParser(description=__doc__)
parser.add_argument("paths", nargs="*", type=Path, default=[root / "Assets", root / "Packages"])
parser.add_argument("--fix", action="store_true")
options = parser.parse_args()
violations = []
for path in options.paths:
    if not path.exists():
        parser.error(f"Missing path: {path}")
    for source in sorted(path.rglob("*.cs")) if path.is_dir() else [path]:
        original = source.read_bytes()
        lines = original.decode("utf-8").splitlines(keepends=True)
        for number, line in enumerate(lines):
            indent = re.match(r"^[ \t]*(?=\S)", line)
            if indent is None:
                continue
            body = line[len(indent[0]):]
            expected = "" if re.match(r"#(?:if|elif|else|endif|define|undef|region|endregion|pragma|nullable)\b", body) else indent[0].expandtabs(4)
            if expected != indent[0]:
                violations.append(f"{source}:{number + 1}")
                lines[number] = expected + body
        result = "".join(lines).encode("utf-8")
        if options.fix and original != result:
            source.write_bytes(result)
if violations and not options.fix:
    raise SystemExit("Check indentation at\n" + "\n".join(violations))
