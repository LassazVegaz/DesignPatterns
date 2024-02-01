using CompositePattern.Core;

namespace CompositePattern.Shapes;

internal class Circle : ICostObject
{
    private const double COST_PER_SQUARE_METER = 0.5;

    public double Radius { get; init; }

    public double CalculateArea() => Math.PI * Radius * Radius;

    public double CalculateCost() => CalculateArea() * COST_PER_SQUARE_METER;
}
