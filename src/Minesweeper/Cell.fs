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
    let string v =
        match v with
        | Covered _ -> "."




