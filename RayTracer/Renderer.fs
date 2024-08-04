module Renderer

open Camera
open Scene
open Image
open Vector
open Shape
open Color
open Ray

type RenderOptions = {
    Dimensions: Vector2I
}

let render (camera: Camera) (scene: Scene) (options: RenderOptions) : Image =
    let vh = camera.ViewportHeight
    let vw = camera.ViewportHeight * camera.AspectRatio

    let vhDir : Vector3 = { X = 0; Y = -vh; Z = 0 }
    let vwDir : Vector3 = { X = vw; Y = 0; Z = 0 }
    let vcDir = camera.Orientation.Direction |*| camera.FocalLength
   
    let topLeftDir = vcDir |+| (vhDir |*| 0.5 |+| vwDir |*| 0.5) |*| -1
   
    let vwStep = vwDir |/| float options.Dimensions.X
    let vhStep = vhDir |/| float options.Dimensions.Y

    let pWidth = options.Dimensions.X
    let pHeight = options.Dimensions.Y

    let traceRay (i: int) (j: int) : Color =
        let dir = topLeftDir |+| (vhStep |*| (float i)) |+| (vwStep |*| (float j))
        let ray = { Origin = camera.Orientation.Origin; Direction = dir }
        let intersections =
            scene.Shapes
            |> List.map intersect ray
            |> List.filter Option.isSome
            |> List.sortBy _.Value.Time
        let color =
            match intersections with
            | x :: _ -> Colors.white
            | _ -> Colors.black
        color

    let pixels =
        [0..(pWidth * pHeight)]
        |> List.map (fun x -> (x / pWidth, x % pHeight))
        |> List.map (fun (i, j) -> traceRay i j)

    { Dimensions = options.Dimensions; Pixels = pixels }
