### What is this repo?
- This is a small Console app that runs ```winget update``` with some parameters to make sure you don't have to click prompts. The point of the project is to use the included powershell script to schedule it within Windows Task Scheduler to ensure your computers applications are up to date.

### Prerequisites
- Windows 11 (Haven't tested on other versions, but very likely to work on at least Windows 10.)
- Winget https://github.com/microsoft/winget-cli
- .NET 9

### How do I use it?
- Do a one time run of the included powershell script. 
  - ```cd ..\repos\WingetAutomation ```
  - ```.\wingetAuto.ps1 -DaysOfWeek Sunday -AtTime 12:00 -KeepAlive 1```
    - Params:
      - DaysOfWeek: What day or days to run on, comma separated.
        - Mandatory: No
        - Default Value: Friday
      - AtTime: Time to run on.
        - Mandatory: No
        - Default Value: 12:00
      - KeepAlive: Whether or not to keep the console alive after execution.
        - Mandatory: No
        - Default Value: 0

### Troubleshooting
- The program will write output in its console, but if you want more detailed Troubleshooting open up a terminal and type ```winget list --logs```
- If you don't trust the terminal output you can open the Task Scheduler GUI and it should be visible like this.
![Task Scheduler](taskScheduler.png)
