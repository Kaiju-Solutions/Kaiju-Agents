$python = if ($env:OS -eq 'Windows_NT') { 'python' } else { 'python3' }
& $python "$PSScriptRoot/Tools/test_cache.py" @args
exit $LASTEXITCODE
