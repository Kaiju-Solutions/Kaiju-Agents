$python = if ($env:OS -eq 'Windows_NT') { 'python' } else { 'python3' }
if ($args.Count -eq 0) {
    & $python "$PSScriptRoot/Tools/smoke_install.py" --local-release --version 6000.7.0b10 7000.0.0a21
} else {
    & $python "$PSScriptRoot/Tools/smoke_install.py" @args
}
exit $LASTEXITCODE
