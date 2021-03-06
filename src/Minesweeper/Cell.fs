namespace Minesweeper

type Cell =
    | Covered of Cell
    | Bomb
    | One
    | Two
    | Three
    | Four
    | Five
    | Six
    | Seven
    | Eight
    | Zero

module Cell =
    let init = Covered Zero
    let char = function
        | Covered _ -> '.'
        | One -> '1'
        | Two -> '2'
        | Three -> '3'
        | Four -> '4'
        | Five -> '5'
        | Six -> '6'
        | Seven -> '7'
        | Eight -> '8'
        | Zero -> '0'
        | Bomb -> '*'

    let charUncovered = function
        | Covered x -> x |> char
        | v -> v |> char

    let rec add v =
        match v with
        | Covered x -> x |> add |> Covered 
        | Zero -> One
        | One -> Two
        | Two -> Three
        | Three -> Four
        | Four -> Five
        | Five -> Six
        | Six -> Seven
        | Seven -> Eight
        | _ -> v

    let click v =
        match v with
        | Covered x -> x
        | _ -> v

    let rec isBomb = function
        | Bomb -> true
        | Covered x -> x |> isBomb
        | _ -> false
