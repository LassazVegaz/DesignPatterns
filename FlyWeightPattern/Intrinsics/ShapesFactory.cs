namespace FlyWeightPattern.Intrinsics;

internal class ShapesFactory
{
    public static readonly ShapesFactory instance = new();


    private readonly List<Shape> cache = [];


    private ShapesFactory() { }


    public Shape CreateShape(ShapeType type, Color color)
    {
        var shape = cache.SingleOrDefault(s => s.shapeType == type && s.color == color);

        if (shape == null)
        {
            shape = new(type, color);
            cache.Add(shape);
        }

        return shape;
    }
}
