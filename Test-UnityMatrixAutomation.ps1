$python = if ($env:OS -eq 'Windows_NT') { 'python' } else { 'python3' }
& $python "$PSScriptRoot/Tools/test_automation.py" @args
exit $LASTEXITCODE
