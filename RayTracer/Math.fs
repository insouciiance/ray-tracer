module Math

open System.Diagnostics

[<Literal>]
let tolerance = 0.00000001

let isZero x =
    x > -tolerance && x < tolerance

let solveQuadraticEquation a b c =
    let d = b * b - 4. * a * c
    match d with
    | x when x > 0 -> [(-b + sqrt d) / (2. * a); (-b - sqrt d) / (2. * a)]
    | x when x = 0 -> [-b / (2. * a)]
    | x when x < 0 -> []
    | _ -> raise (UnreachableException())
