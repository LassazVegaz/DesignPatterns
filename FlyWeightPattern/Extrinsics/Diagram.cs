using FlyWeightPattern.Core;

namespace FlyWeightPattern.Extrinsics;

internal class Diagram(IDrawable drawable)
{
    public int X { get; set; }
    public int Y { get; set; }
    public IDrawable Drawable { get; set; } = drawable;

    public void Draw() => Drawable.Draw(X, Y);
}
