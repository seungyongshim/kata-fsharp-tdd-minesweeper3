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
    let string = function
        | Covered _ -> "."
        | One -> "1"
        | Two -> "2"
        | Three -> "3"
        | Four -> "4"
        | Five -> "5"
        | Six -> "6"
        | Seven -> "7"
        | Eight -> "8"
        | Zero -> "0"
        | Bomb -> "*"

    let rec add v =
        match v with
        | Covered x -> x |> add 


