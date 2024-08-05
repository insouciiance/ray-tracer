module RayTracer.Sample

open Renderer
open Shape
open Scene
open Camera
open Image

[<EntryPoint>]
let main args =
    let camera = {
        Orientation = { Origin = { X = 0; Y = 0; Z = 0 }; Direction = { X = 0; Y = 0; Z = -1 } }
        AspectRatio = 16. / 9.
        FocalLength = 1
        ViewportHeight = 2
    }

    let scene = {
        Shapes = [
            //Plane({ X = 0; Y = -0.2; Z = 0 }, { X = 0; Y = 1; Z = 0 });
            Sphere({ X = 0; Y = 0.5; Z = -1.5 }, 0.5)
            Sphere({ X = -0.5; Y = -0.5; Z = -1.5 }, 0.5)
            Sphere({ X = 0.5; Y = -0.5; Z = -1.5 }, 0.5)
        ]
    }

    let renderOptions = {
        Dimensions = { X = 80; Y = 45 }
    }

    let image = render camera scene renderOptions

    dump Console image

    0
