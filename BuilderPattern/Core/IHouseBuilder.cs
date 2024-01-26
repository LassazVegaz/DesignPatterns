using BuilderPattern.Models;

namespace BuilderPattern.Core;

public enum Count
{
    Max,
    Medium,
    Min
}

public interface IHouseBuilder
{
    void AddDoors(Count count);
    void AddFloors(Count count);
    void AddRooms(Count countPerFloor);
    void AddBathrooms(Count countPerFloor);
    House BuildHouse();
}
