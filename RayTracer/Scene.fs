module Scene

open Light
open Shape

type Scene = {
    Shapes: Shape list
    Light: Light
}
