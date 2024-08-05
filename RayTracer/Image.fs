module Image

open System
open System.Drawing
open System.Text
open Color
open Vector

type Image = {
    Dimensions: Vector2I
    Pixels: Color list
}

type OutputKind =
    | Console
    | File of path: string

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

let dumpFile (image: Image) (path: string) : unit =
    let bitmap = new Bitmap(image.Dimensions.X, image.Dimensions.Y)
    
    let writePixel (i: int) (p: Color) =
        let x = i % image.Dimensions.X
        let y = i / image.Dimensions.X
        bitmap.SetPixel(x, y, stdColor p)

    image.Pixels
    |> List.iteri (fun i p -> writePixel i p)
    
    bitmap.Save path


let dump (image: Image) (kind: OutputKind) : unit =
    match kind with
    | Console -> dumpConsole image
    | File path -> dumpFile image path
