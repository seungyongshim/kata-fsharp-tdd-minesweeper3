module Tests

open System
open Xunit
open Minesweeper
open Minesweeper.Cell

[<Fact>]
let Should_be_Covered () =
    let sut = init
    Assert.Equal(".", sut |> string)

[<Fact>]
let Should_be_One () =
    let sut = One
    Assert.Equal("1", sut |> string)

[<Fact>]
let Should_be_Two() =
    let sut = Two
    Assert.Equal("2", sut |> string)
