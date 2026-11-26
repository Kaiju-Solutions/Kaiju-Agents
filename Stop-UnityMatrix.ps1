$python = if ($env:OS -eq 'Windows_NT') { 'python' } else { 'python3' }
& $python "$PSScriptRoot/Tools/matrix_control.py" @args
exit $LASTEXITCODE
