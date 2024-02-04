using FlyWeightPattern.Core;

namespace FlyWeightPattern.Intrinsics;

internal enum ShapeType
{
    Circle,
    Square,
    Rectangule,
}

internal enum Color
{
    Red, Green, Blue,
}

internal class Shape(ShapeType type, Color color) : IDrawable
{
    public readonly ShapeType shapeType = type;
    public readonly Color color = color;

    public void Draw(int x, int y)
    {
        Console.WriteLine($"Drawing a {color} {shapeType} at ({x} , {y})");
    }
}
