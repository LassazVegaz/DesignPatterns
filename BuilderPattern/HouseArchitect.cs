using BuilderPattern.Core;
using BuilderPattern.Models;

namespace BuilderPattern;

public enum LuxuryLevel
{
    High,
    Medium,
    Low
}

public class HouseArchitect(IHouseBuilder builder, LuxuryLevel luxuryLevel)
{
    public House BuildHouse()
    {
        var count = luxuryLevel switch
        {
            LuxuryLevel.Low => Count.Min,
            LuxuryLevel.Medium => Count.Medium,
            LuxuryLevel.High => Count.Max,
            _ => throw new ArgumentOutOfRangeException(nameof(luxuryLevel), luxuryLevel, null)
        };

        builder.AddFloors(count);
        builder.AddDoors(count);
        builder.AddBathrooms(count);
        builder.AddRooms(count);

        return builder.BuildHouse();
    }
}
