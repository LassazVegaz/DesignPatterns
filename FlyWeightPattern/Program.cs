using FlyWeightPattern.Extrinsics;
using FlyWeightPattern.Intrinsics;

const int DIAGRAMS_COUNT = 1000;

var shapeTypeNumberUpperBound = (int)Enum.GetValues<ShapeType>().Max() + 1;
var colorNumberUpperBound = (int)Enum.GetValues<Color>().Max() + 1;
var diagrams = new List<Diagram>();

for (var i = 0; i < DIAGRAMS_COUNT; i++)
{
    var shapeType = (ShapeType)Random.Shared.Next(shapeTypeNumberUpperBound);
    var color = (Color)Random.Shared.Next(colorNumberUpperBound);
    var shape = ShapesFactory.instance.CreateShape(shapeType, color);
    diagrams.Add(new(shape));
}

var stats = diagrams.GroupBy(d => (Shape)d.Drawable).Select(g => new
{
    ShapeType = g.Key.shapeType,
    Color = g.Key.color,
    Count = g.Count(),
});

foreach (var stat in stats)
{
    Console.WriteLine($"{stat.Count} {stat.Color} {stat.ShapeType}s are created");
}