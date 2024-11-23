module ProcessStartInfoHelper

open System.Diagnostics

type OutputType =
    | StdError
    | StdOutput

[<AbstractClass; Sealed>]
type ProcessStartInfoHelper() =
 static member printOutput (cmd: Process) (outputType: OutputType) =
    match outputType with
    | StdError ->
        printfn "Errors:"
        cmd.StandardError.ReadToEnd() |> printfn "%A"
    | StdOutput ->
        printfn "Output:"
        cmd.StandardOutput.ReadToEnd() |> printfn "%s"