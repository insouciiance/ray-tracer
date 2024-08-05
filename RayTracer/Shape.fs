module Shape

open Vector
open Ray
open Math
open IntersectionResult

type Shape =
    | Plane of basePoint: Vector3 * normal: Vector3
    | Sphere of center: Vector3 * radius: float

let intersectPlane (ray: Ray) (basePoint: Vector3) (normal: Vector3) : Option<IntersectionResult> =
    let denominator = dot normal ray.Direction

    match abs denominator with
    | x when not (isZero x) ->
        let t = (dot (basePoint |-| ray.Origin) normal) / denominator
        match t with
        | x when x >= 0 -> Some { Point = ray.Origin |+| (ray.Direction |*| t); Normal = normal; Time = t }
        | _ -> None
    | _ -> None

let intersectSphere (ray: Ray) (center: Vector3) (radius: float) : Option<IntersectionResult> =
    let k = ray.Origin |-| center
    let a = dot ray.Direction ray.Direction
    let b = 2. * dot k ray.Direction
    let c = dot k k - radius * radius
    let roots = solveQuadraticEquation a b c
    match (roots, b) with
    | ([], _) -> None
    | (_, x) when x >= 0 -> None
    | (l, _) ->
        let closest = List.min l
        let point = ray.Origin |+| (ray.Direction |*| closest)
        Some { Point = point; Time = closest; Normal = normalize (point |-| center) }

let intersect (ray: Ray) (shape: Shape) : Option<IntersectionResult> =
    match shape with
    | Plane (basePoint, normal) -> intersectPlane ray basePoint normal
    | Sphere (center, radius) -> intersectSphere ray center radius
