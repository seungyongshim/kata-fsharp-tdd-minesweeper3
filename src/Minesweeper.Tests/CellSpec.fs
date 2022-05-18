module Tests

open System
open Xunit
open Minesweeper
open Minesweeper.Cell

[<Fact>]
let Should_be_Covered () =
    let sut = init
    
    Assert.Equal(".", sut |> string)
