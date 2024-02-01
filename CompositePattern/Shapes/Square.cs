using CompositePattern.Core;

namespace CompositePattern.Shapes;

internal class Square : ICostObject
{
    const double COST_PER_SQUARE_METER_1 = 2;
    const double COST_PER_SQUARE_METER_2 = 1.5;
    const double COST_PER_SQUARE_METER_3 = 1.25;
    const double COST_PER_SQUARE_METER_4 = 1.0;

    const double BREAKPOINT_1 = 100;
    const double BREAKPOINT_2 = 200;
    const double BREAKPOINT_3 = 300;

    public double SideLength { get; init; }

    public double CalculateCost()
    {
        var area = SideLength * SideLength;
        var costPerSquareMeter = area switch
        {
            < BREAKPOINT_1 => COST_PER_SQUARE_METER_1,
            < BREAKPOINT_2 => COST_PER_SQUARE_METER_2,
            < BREAKPOINT_3 => COST_PER_SQUARE_METER_3,
            _ => COST_PER_SQUARE_METER_4,
        };
        return area * costPerSquareMeter;
    }
}
