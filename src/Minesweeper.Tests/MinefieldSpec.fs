module MinefieldSpec

open Xunit
open Minesweeper
open Minesweeper.Minefield
open FSharpPlus

[<Fact>]
let Should_be_Create () =
    let sut = Setup (4, 3) |> start
    Assert.Equal(". . . .\n. . . .\n. . . .\n", sut |> string)

[<Fact>]
let Should_be_Create_With_Bombs () =
    let sut = SetupWithBombs (4, 3, seq {(1, 0)}) |> start
    Assert.Equal(1, sut |> cells
                        |> Map.toSeq
                        |> Seq.filter (fun ((y, x), c) -> c |> Cell.isBomb)
                        |> Seq.length)
