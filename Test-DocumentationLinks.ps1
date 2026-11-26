$python = if ($env:OS -eq 'Windows_NT') { 'python' } else { 'python3' }
& $python "$PSScriptRoot/Tools/documentation_links.py" @args
exit $LASTEXITCODE
