module WingetUpdate

open System.Diagnostics
open ProcessStartInfoHelper

let runWingetUpdate() =
    try
        let processStartInfo = new ProcessStartInfo("winget")
        processStartInfo.Arguments <- "update --all --include-unknown --accept-package-agreements --accept-source-agreements"
        processStartInfo.UseShellExecute <- false
        processStartInfo.CreateNoWindow <- true
        processStartInfo.WindowStyle <- ProcessWindowStyle.Minimized
        processStartInfo.RedirectStandardError <- true
        processStartInfo.RedirectStandardOutput <- true

        use cmd = Process.Start(processStartInfo)
        cmd.WaitForExit()
        
        ProcessStartInfoHelper.printOutput cmd StdError
        ProcessStartInfoHelper.printOutput cmd StdOutput
    with
    | ex ->
        printfn "An error occurred: %A" ex.Message