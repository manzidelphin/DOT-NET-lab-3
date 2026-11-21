param(
    [string]$XamppPath = 'C:\xampp',
    [string]$Destination = "$env:LOCALAPPDATA\SalonFlow\Backups",
    [int]$Port = 3306,
    [string]$OptionsFile = ''
)

$ErrorActionPreference = 'Stop'
$dump = Join-Path $XamppPath 'mysql\bin\mysqldump.exe'
if (!(Test-Path $dump)) { throw "mysqldump.exe was not found at $dump" }
New-Item -ItemType Directory -Force -Path $Destination | Out-Null
$target = Join-Path $Destination ("salonflow-{0}.sql" -f (Get-Date -Format 'yyyy-MM-dd_HHmmssfff'))
$dumpArgs = @()
if ($OptionsFile) { $dumpArgs += "--defaults-extra-file=$OptionsFile" }
else { $dumpArgs += '--no-defaults'; $dumpArgs += '--user=root' }
$dumpArgs += @('--host=127.0.0.1', "--port=$Port", '--protocol=tcp', '--single-transaction',
    '--default-character-set=utf8mb4', "--result-file=$target", '--databases', 'salonflow_db')
& $dump @dumpArgs
if ($LASTEXITCODE -ne 0) {
    Remove-Item -LiteralPath $target -ErrorAction SilentlyContinue
    throw "Database backup failed. Check XAMPP MySQL and the backup credentials."
}
Get-ChildItem -LiteralPath $Destination -Filter 'salonflow-*.sql' -File |
    Where-Object { $_.LastWriteTime -lt (Get-Date).AddDays(-30) } |
    Remove-Item
Write-Output $target
