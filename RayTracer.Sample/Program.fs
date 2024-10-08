﻿module RayTracer.Sample

open Renderer
open Shape
open Scene
open Camera
open Image
open Light

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
            Plane({ X = 0; Y = -0.2; Z = 0 }, { X = 0; Y = 1; Z = 0 });
            Sphere({ X = 0; Y = 0.5; Z = -1.5 }, 0.5)
            //Sphere({ X = -0.5; Y = -0.5; Z = -1.5 }, 0.5)
            //Sphere({ X = 0.5; Y = -0.5; Z = -1.5 }, 0.5)
        ]
        Light = Point ({ X = 0; Y = 1.5; Z = -0.55 }, { R = 1; G = 0.25; B = 0 })
    }

    let renderOptions = {
        Dimensions = { X = 1600; Y = 900 }
    }

    let image = render camera scene renderOptions

    dump image (File "result.png")
    System.Diagnostics.Process.Start("explorer.exe", "result.png") |> ignore

    0
