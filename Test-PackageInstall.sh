#!/usr/bin/env bash
set -eu
python_bin=python3
if ! python3 -c 'import sys' >/dev/null 2>&1; then
    python_bin=python
fi
if [ "$#" -eq 0 ]; then
    set -- --local-release --version 6000.7.0b10 7000.0.0a21
fi
exec "$python_bin" "$(dirname "$0")/Tools/smoke_install.py" "$@"
