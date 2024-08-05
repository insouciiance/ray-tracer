module Image

open System
open System.Text
open Color
open Vector

type Image = {
    Dimensions: Vector2I
    Pixels: Color list
}

type OutputKind =
    | Console

let dumpConsole (image: Image) : unit =
    let sb = new StringBuilder()

    let colorToChar (p: Color) : char =
        match p with
        | x when x.R > 0.75 && x.G > 0.75 && x.B > 0.75 -> '$'
        | x when x.R > 0.5 && x.G > 0.5 && x.B > 0.5 -> '%'
        | x when x.R > 0.25 && x.G > 0.25 && x.B > 0.25 -> '*'
        | _ -> '.'

    let writePixel (i: int) (p: Color) =
        sb.Append (colorToChar p) |> ignore

        let newline =
            match i + 1 with
            | x when x % image.Dimensions.X = 0 -> "\n"
            | _ -> ""

        sb.Append newline |> ignore

    image.Pixels
    |> List.iteri (fun i p -> writePixel i p)

    let result = sb.ToString()
    Console.WriteLine result


let dump (kind: OutputKind) (image: Image) : unit =
    match kind with
    | Console -> dumpConsole image
