module Vector

open System.Numerics

type Vector2<'T> when 'T :> INumber<'T> = {
    X: 'T
    Y: 'T
}

type Vector2I = Vector2<int>

type Vector2 = Vector2<float>

type Vector3<'T> when 'T :> INumber<'T> = {
    X: 'T
    Y: 'T
    Z: 'T
}

type Vector3I = Vector3<int>

type Vector3 = Vector3<float>

let (|+|) (v1: Vector3<'T>) (v2: Vector3<'T>) : Vector3<'T> = {
        X = v1.X + v2.X
        Y = v1.Y + v2.Y
        Z = v1.Z + v2.Z
    }

let (|-|) (v1: Vector3<'T>) (v2: Vector3<'T>) : Vector3<'T> = {
        X = v1.X - v2.X
        Y = v1.Y - v2.Y
        Z = v1.Z - v2.Z
    }

let (|*|) (v: Vector3<'T>) (x: 'T) : Vector3<'T> = {
        X = v.X * x
        Y = v.Y * x
        Z = v.Z * x
    }

let (|/|) (v: Vector3<'T>) (x: 'T) : Vector3<'T> = {
        X = v.X / x
        Y = v.Y / x
        Z = v.Z / x
    }

let dot (v1: Vector3<'T>) (v2: Vector3<'T>) =
    v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z
