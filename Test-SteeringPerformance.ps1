$python = if ($env:OS -eq 'Windows_NT') { 'python' } else { 'python3' }
& $python "$PSScriptRoot/Tools/Benchmarks/steering.py" @args
exit $LASTEXITCODE
