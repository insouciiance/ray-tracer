module Shape

open Vector
open Ray
open Math
open IntersectionResult

type Shape =
    | Plane of basePoint: Vector3 * normal: Vector3

let intersectPlane (ray: Ray) (basePoint: Vector3) (normal: Vector3) : Option<IntersectionResult> =
    let denominator = dot normal ray.Direction

    match abs denominator with
    | x when isZero x ->
        let t = dot (basePoint |-| ray.Origin) normal
        match t with
        | x when x > 0 -> Some { Point = ray.Origin |+| (ray.Direction |*| t); Normal = normal; Time = t }
        | _ -> None
    | _ -> None

let intersect (ray: Ray) (shape: Shape) : Option<IntersectionResult> =
    match shape with
    | Plane (basePoint, normal) -> intersectPlane ray basePoint normal
