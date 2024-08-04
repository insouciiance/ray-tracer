module Image

open Color
open Vector

type Image = {
    Dimensions: Vector2I
    Pixels: Color list
}
