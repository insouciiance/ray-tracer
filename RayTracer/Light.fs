module Light

open Vector
open Color

type Light =
    | Point of origin: Vector3 * color: Color
