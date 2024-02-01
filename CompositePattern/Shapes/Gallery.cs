using CompositePattern.Core;

namespace CompositePattern.Shapes;

internal class Gallery(params ICostObject[] shapes) : ICostObject
{
    private readonly ICostObject[] _shapes = shapes;

    public double CalculateCost() => _shapes.Sum(s => s.CalculateCost());
}
