$python = if ($env:OS -eq 'Windows_NT') { 'python' } else { 'python3' }
& $python "$PSScriptRoot/Tools/matrix_results.py" @args
exit $LASTEXITCODE
