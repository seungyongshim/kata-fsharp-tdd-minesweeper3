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
let Should_be_string () =
    let sut = seq {init; Zero; One; Two; Three; Four; Five; Six; Seven; Eight; Bomb}
    let exp = seq {"."; "0"; "1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "*"}

    for (cell, str) in ((sut, exp) ||> Seq.zip) do
        Assert.Equal(str, cell |> string) 

[<Fact>]
let Should_be_add() =
    let sut = seq {init; Zero; One; Two; Three; Four; Five; Six; Seven; Eight; Bomb}
    let exp = seq {"."; "1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "8"; "*"}
    let ret = sut |> Seq.map add

    for (cell, str) in ((ret, exp) ||> Seq.zip) do
        Assert.Equal(str, cell|> string)

