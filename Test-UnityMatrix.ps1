$python = if ($env:OS -eq 'Windows_NT') { 'python' } else { 'python3' }
& $python "$PSScriptRoot/Tools/unity_matrix.py" @args
exit $LASTEXITCODE
