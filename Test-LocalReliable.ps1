$python = if ($env:OS -eq 'Windows_NT') { 'python' } else { 'python3' }
& $python "$PSScriptRoot/Tools/local_reliable.py" @args
exit $LASTEXITCODE
