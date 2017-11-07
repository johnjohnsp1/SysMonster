 
$EventLogEventRead  = { param($p1,$p2) Write-Host $p2.EventRecord.FormatDescription() -ForegroundColor Green }


$watcher = new-object System.Diagnostics.Eventing.Reader.EventLogWatcher -ArgumentList "Microsoft-Windows-Sysmon/Operational"
Register-ObjectEvent -InputObject $watcher -EventName "EventRecordWritten" -Action $EventLogEventRead
$watcher.Enabled = $true
while($true)
{
}
