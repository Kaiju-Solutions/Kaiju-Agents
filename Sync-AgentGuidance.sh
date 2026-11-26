#!/usr/bin/env bash
set -eu
python_bin=python3
if ! python3 -c 'import sys' >/dev/null 2>&1; then
    python_bin=python
fi
exec "$python_bin" "$(dirname "$0")/Tools/guidance.py" "$@"
