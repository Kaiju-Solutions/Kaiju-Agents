$python = if ($env:OS -eq 'Windows_NT') { 'python' } else { 'python3' }
& $python "$PSScriptRoot/Tools/csharp_style.py" @args
exit $LASTEXITCODE
