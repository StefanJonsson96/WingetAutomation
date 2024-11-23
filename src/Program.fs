open WingetUpdate
open System

[<EntryPoint>]
let public main(args: string[]) =
    let keepAlive = args |> Array.tryFindIndex (fun arg -> arg = "-KeepAlive") |> Option.defaultValue -1 >= 0
    runWingetUpdate() |> ignore
    printfn $"Successfully ran winget update."
    if keepAlive then
      Console.ReadLine() |> ignore
    0
