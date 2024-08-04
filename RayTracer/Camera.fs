module Camera

open Ray

type Camera = {
     Orientation: Ray
     AspectRatio: float
     FocalLength: float
     ViewportHeight: float
}
