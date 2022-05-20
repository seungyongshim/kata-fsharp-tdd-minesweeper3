namespace Minesweeper

open System.Text
open FSharpPlus
open Cell

type Minefield =
    | Setup of width: int * height: int
    | SetupWithBombs of width: int * height: int * seq<(int*int)>
    | Playing of width: int * height: int * Map<(int*int), Cell>

module Minefield = 
    let rec start v =
        match v with
        | SetupWithBombs (w, h, z) ->
            let nearBombsPos (y, x) = seq {
                (y - 1, x - 1) ;
                (y - 1, x);
                (y - 1, x + 1);
                (y    , x - 1) ;
                (y    , x + 1);
                (y + 1, x - 1) ;
                (y + 1, x);
                (y + 1, x + 1);
            }
            let cells = Map.ofSeq <| seq {
                for y in {0..h - 1} do
                for x in {0..w - 1} do
                yield ((y, x), init)
            }
            let cellsWithBombs =
                (cells, z) ||> Seq.fold (fun s p -> s |> Map.change p (fun o ->
                    match o with
                    | Some _ -> Bomb |> Covered |> Some
                    | _ -> o))
            let cellsWithBombsAndNumber =
                (cellsWithBombs, z) ||> Seq.fold (fun s p -> 
                    (s, nearBombsPos(p)) ||> Seq.fold(fun s1 p1 -> s1 |> Map.change p1 (fun o ->
                    match o with
                    | Some x -> x |> add |> Some
                    | _ -> o)))
            Playing (w, h, cellsWithBombsAndNumber)
        | Setup (w, h) -> SetupWithBombs (w, h, Seq.empty) |> start
        | _ -> v
    let string v (f : Cell -> char) =
        match v with
        | Playing (w, h, z) ->
            (StringBuilder(), z |> Map.toSeq) ||> fold (fun s ((y, x), c) ->
                let _1 = s.Append (c |> f)
                match x with
                | _ when x = w - 1 -> _1.Append '\n'
                | _ -> _1.Append ' ') |> string
    let cells = function
        | Playing (w, h, z) -> z
        | _ -> Map.empty



