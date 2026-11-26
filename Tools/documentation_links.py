"""Validate file links and embedded images in the offline edition."""
from html.parser import HTMLParser
from pathlib import Path
from urllib.parse import unquote, urlsplit


class Links(HTMLParser):
    def __init__(self, page):
        super().__init__()
        self.page = page

    def handle_starttag(self, tag, attrs):
        for key, value in attrs:
            if key not in ("href", "src") or not value:
                continue
            url = urlsplit(value)
            if url.scheme or url.netloc or not url.path:
                continue
            if not (self.page.parent / unquote(url.path)).is_file():
                raise SystemExit(f"{self.page}: missing {value}")


def check():
    root = Path(__file__).resolve().parents[1] / "Packages/ca.kaijusolutions.agents/Documentation~"
    for page in root.rglob("*.html"):
        Links(page).feed(page.read_text(encoding="utf-8"))


if __name__ == "__main__":
    check()
