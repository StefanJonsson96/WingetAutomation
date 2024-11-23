param(
    [Parameter(Mandatory=$false)]
    [string[]]$DaysOfWeek = "Friday",

    [Parameter(Mandatory=$false)]
    [string]$AtTime = "12:00",

    [Parameter(Mandatory=$false)]
    [bool]$KeepAlive
)

# Check if the task already exists
$existingTask = Get-ScheduledTask | Where-Object {$_.TaskName -eq "WingetAutomationTask"}

if ($existingTask) {
    Write-Warning "Task WingetAutomationTask already exists. Skipping creation."
    return
}

# Get User Info
$currentDomain = [Environment]::UserDomainName
$currentUser = [Environment]::UserName

# Remove existing build files
if (Get-ChildItem -Recurse -Directory | Where-Object {$_.Name -eq "obj" -or $_.Name -eq "bin"}) {
    Get-ChildItem -Recurse -Directory | Where-Object {$_.Name -eq "obj" -or $_.Name -eq "bin"} 
    | Remove-Item -Recurse -Force
}

# Build the F# project
dotnet build ".\src\WingetAutomation.fsproj" -c Release -o src\bin\Release\net9.0

# Path to the built executable
$exePath = Resolve-Path ".\src\bin\Release\net9.0\WingetAutomation.exe"

# Create a new task action
$taskAction = New-ScheduledTaskAction -Execute $exePath -Argument "-KeepAlive $keepAlive"

# Create the trigger
$trigger = New-ScheduledTaskTrigger -Weekly -At $AtTime -DaysOfWeek $DaysOfWeek

# Create the task
Register-ScheduledTask -Action $taskAction -Trigger $trigger -TaskName "WingetAutomationTask" -User "$currentDomain\$currentUser"

# Ensure task is scheduled
$existingTask = Get-ScheduledTask | Where-Object {$_.TaskName -eq "WingetAutomationTask"}