"""Bundle the authored manual with local page and illustration links for offline use."""
import argparse
import html
from pathlib import Path
import re

from api_reference import generate
import markdown

ROOT = Path(__file__).resolve().parents[1]
SOURCE = ROOT / "Documentation"
TARGET = ROOT / "Packages/ca.kaijusolutions.agents/Documentation~"


def build(check=False):
    outputs = {}
    pages = generate(TARGET.parent)
    anchors = {name: re.findall(r'<a id="([^"]+)"></a>', body) for name, body in pages.items()}
    titles = []
    for source in sorted((SOURCE / "manual").glob("*.md")):
        body = source.read_text(encoding="utf-8-sig")
        body = re.sub(r"https://agents\.kaijusolutions\.ca/manual/([\w-]+)(?:\.html|\.md)", r"\1.md", body)
        body = body.replace("https://agents.kaijusolutions.ca/img/", "img/")
        def local_api(match):
            path = f"api/{match[1]}.md"
            if path not in pages:
                return match[0]
            fragment = match[2] or ""
            member = next((a for a in sorted(anchors[path], key=len, reverse=True)
                           if fragment == a or fragment.startswith(a + "_")), None)
            return path + ("#" + member if member else "")
        body = re.sub(r"https://agents\.kaijusolutions\.ca/api/([\w.-]+)\.html(?:#([\w.-]+))?", local_api, body)
        pages[source.name] = body
        titles.append((body.splitlines()[0].lstrip("# "), source.name))

    pages["index.md"] = "# Kaiju Agents\n\nOffline manual for Unity 6.7 and Unity 7.\n\n" + "\n".join(
        f"- [{title}]({name})" for title, name in sorted(titles, key=lambda item: item[1] != "getting-started.md")) + "\n"
    pages["index.md"] += "- [Scripting reference](api/index.md)\n"
    for name, body in pages.items():
        outputs[name] = body.encode("utf-8")
        article = markdown.markdown(body, extensions=["fenced_code", "tables", "toc", "sane_lists"])
        article = re.sub(r'href="([\w./-]+)\.md([#"])', r'href="\1.html\2', article)
        title = html.escape(body.splitlines()[0].lstrip("# "))
        home = "../index.html" if name.startswith("api/") else "index.html"
        page = f"""<!doctype html>
<html lang="en"><head><meta charset="utf-8"><meta name="viewport" content="width=device-width, initial-scale=1">
<title>{title} | Kaiju Agents</title><style>
body{{font:1rem/1.6 system-ui,sans-serif;max-width:54rem;margin:2rem auto;padding:0 1rem;color:#222}}
img{{max-width:100%;height:auto}}pre{{padding:1em;background:#f2f4f5;overflow:auto}}a{{color:#174a90}}
</style></head><body><nav><a href="{home}">Kaiju Agents manual</a></nav><main>{article}</main></body></html>
"""
        outputs[Path(name).with_suffix(".html").as_posix()] = page.encode("utf-8")
    for image in (SOURCE / "img").glob("*"):
        outputs[f"img/{image.name}"] = image.read_bytes()
    # The directory is generated exclusively by this builder.
    for path in TARGET.rglob("*") if TARGET.exists() else ():
        if path.is_file() and path.relative_to(TARGET).as_posix() not in outputs:
            if check:
                raise SystemExit(f"Stale generated documentation: {path}")
            path.unlink()
    for name, data in outputs.items():
        path = TARGET / name
        if check:
            existing = path.read_bytes() if path.is_file() else None
            if existing and path.suffix in (".md", ".html"):
                existing = existing.replace(b"\r\n", b"\n")
            if existing != data:
                raise SystemExit(f"Offline documentation differs: {path}")
        else:
            path.parent.mkdir(parents=True, exist_ok=True)
            path.write_bytes(data)


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--check", action="store_true")
    build(parser.parse_args().check)
