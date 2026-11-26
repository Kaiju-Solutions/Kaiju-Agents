$python = if ($env:OS -eq 'Windows_NT') { 'python' } else { 'python3' }
& $python "$PSScriptRoot/Tools/api_reference.py" @args
exit $LASTEXITCODE
