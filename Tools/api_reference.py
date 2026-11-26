"""Extract public C# declarations for the package's offline source reference."""
from collections import defaultdict
from html import unescape
from pathlib import Path
import re
from urllib.parse import quote

from tree_sitter import Language, Parser
import tree_sitter_c_sharp

TYPES = {"class_declaration", "enum_declaration", "interface_declaration", "struct_declaration",
         "delegate_declaration", "record_declaration"}


def content(node):
    return node.text.decode("utf-8")


def visible(node):
    return any(c.type == "modifier" and content(c) in ("public", "protected") for c in node.children)


def signature(node):
    pieces = []
    for child in node.children:
        if child.type in ("arrow_expression_clause", "block", "accessor_list", "declaration_list",
                          "enum_member_declaration_list", "constructor_initializer", ";", "="):
            break
        if child.type == "variable_declaration":
            field_type = child.child_by_field_name("type")
            names = [content(item.child_by_field_name("name")) for item in child.named_children
                     if item.type == "variable_declarator" and item.child_by_field_name("name")]
            pieces.extend((content(field_type), ", ".join(names)))
            break
        if child.type not in ("attribute_list", "comment"):
            pieces.append(content(child))
    if node.type == "property_declaration":
        accessors = node.child_by_field_name("accessors")
        if accessors:
            names = [content(a).split("=>")[0].split("{")[0].strip().rstrip(";") + ";"
                     for a in accessors.named_children if a.type == "accessor_declaration"]
            pieces.append("{ " + " ".join(names) + " }")
        else:
            pieces.append("{ get; }")
    return re.sub(r"\s+", " ", " ".join(pieces)).strip()


def summary(node):
    comments = []
    prev = node.prev_named_sibling
    while prev and prev.type == "comment" and content(prev).startswith("///"):
        comments.append(content(prev)[3:].strip())
        prev = prev.prev_named_sibling
    found = re.search(r"<summary>(.*?)</summary>", " ".join(reversed(comments)))
    if not found:
        return ""
    text = re.sub(r'<see(?:also)? cref="([^"]+)"\s*/>', r"\1", found[1])
    return unescape(re.sub(r"<[^>]+>", "", text)).strip()


def declarations(node):
    for child in node.named_children:
        if child.type.startswith("preproc_"):
            yield from declarations(child)
        else:
            yield child


def generate(package):
    parser = Parser(Language(tree_sitter_c_sharp.language()))
    pages, namespaces = {}, defaultdict(set)

    def collect(node, scope, source):
        for child in declarations(node):
            if child.type == "namespace_declaration":
                collect(child.child_by_field_name("body"), content(child.child_by_field_name("name")), source)
            elif child.type in TYPES and visible(child):
                name = content(child.child_by_field_name("name"))
                params = next((c for c in child.children if c.type == "type_parameter_list"), None)
                suffix = "-" + str(len(params.named_children)) if params else ""
                full = f"{scope}.{name}{suffix}"
                key = f"api/{full}.md"
                namespaces[scope].add(full)
                statements = [f"# {name}", summary(child), "~~~csharp\n" + signature(child) + "\n~~~",
                              f"[Package source](../../{quote(source.as_posix())})"]
                body = child.child_by_field_name("body")
                if body is not None:
                    anchors = set()
                    for member in declarations(body):
                        if member.type in TYPES or (not visible(member) and member.type != "enum_member_declaration"):
                            continue
                        declaration = signature(member)
                        if declaration:
                            name_node = member.child_by_field_name("name")
                            if name_node is None:
                                field = next((c for c in member.named_children if c.type == "variable_declaration"), None)
                                if field:
                                    variable = next((c for c in field.named_children if c.type == "variable_declarator"), None)
                                    name_node = variable.child_by_field_name("name") if variable else None
                            if name_node is not None:
                                member_name = content(name_node)
                                anchor = re.sub(r"[^a-zA-Z0-9]", "_", full + "." + member_name)
                                if anchor not in anchors:
                                    anchors.add(anchor)
                                    statements.append(f'<a id="{anchor}"></a>\n\n### {member_name}')
                            statements.extend(("~~~csharp\n" + declaration + "\n~~~", summary(member)))
                    collect(body, full, source)
                pages[key] = pages.get(key, "") + "\n\n".join(s for s in statements if s) + "\n"

    for folder in ("Editor", "Runtime", "Samples~"):
        for source in sorted((package / folder).rglob("*.cs")):
            # Include declarations from optional packages and Editor-only sections.
            data = re.sub(rb"(?m)^\s*#(?:if|elif|else|endif|region|endregion|pragma|nullable)\b[^\n]*", b"", source.read_bytes())
            collect(parser.parse(data).root_node, "", source.relative_to(package))
    index = ["# Scripting reference"]
    for namespace, types in sorted(namespaces.items()):
        links = [f"- [{name[len(namespace)+1:]}]({name}.md)" for name in sorted(types)]
        key = f"api/{namespace}.md"
        # Nested types share a page name with their enclosing type.
        pages[key] = pages.get(key, f"# {namespace}\n") + "\n" + "\n".join(links) + "\n"
        index.append(f"- [{namespace}]({namespace}.md)")
    pages["api/index.md"] = index[0] + "\n\n" + "\n".join(index[1:]) + "\n"
    return pages


if __name__ == "__main__":
    import argparse
    parser = argparse.ArgumentParser(description=__doc__)
    package = Path(__file__).resolve().parents[1] / "Packages/ca.kaijusolutions.agents"
    parser.add_argument("--output", type=Path, default=package / "Documentation~")
    parser.add_argument("--check", action="store_true")
    args = parser.parse_args()
    for name, body in generate(package).items():
        path = args.output / name
        if args.check:
            if not path.is_file() or path.read_text(encoding="utf-8") != body:
                raise SystemExit(f"Scripting reference differs: {path}")
        else:
            path.parent.mkdir(parents=True, exist_ok=True)
            path.write_bytes(body.encode("utf-8"))
