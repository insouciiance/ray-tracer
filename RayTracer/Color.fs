module Color

type Color = {
    R: float
    G: float
    B: float
}

let clamp (color: Color) : Color = {
        R = min 1. (max 0. color.R)
        G = min 1. (max 0. color.G)
        B = min 1. (max 0. color.B)
    }

let stdColor (color: Color) : System.Drawing.Color =
    System.Drawing.Color.FromArgb(255, int (color.R * 255.), int (color.G * 255.), int (color.B * 255.))
