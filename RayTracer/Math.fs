module Math

[<Literal>]
let tolerance = 0.00000001

let isZero x =
    x > -tolerance && x < tolerance
