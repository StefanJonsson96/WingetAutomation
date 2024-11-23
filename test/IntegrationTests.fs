module IntegrationTests 

open NUnit.Framework
open Program
open System.IO
open System
open System.Text

[<TestFixture>]
type IntegrationTests() =

    [<Test>]
    member x.main_shouldNotHaveErrors_WhenRanSuccessfully()=
        // Arrange
        let outputBuilder = new StringBuilder()
        Console.SetOut(new StringWriter(outputBuilder))

        let args : string [] = [|"-asdasdasd"; "0"|]

        // Act
        main(args) |> ignore

        // Assert
        let capturedOutput = outputBuilder.ToString()
        Assert.That(capturedOutput.Contains("Successfully ran winget update."), Is.True)
        Assert.That(capturedOutput.Contains("An error occurred:"), Is.False)
    