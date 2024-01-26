using BuilderPattern.Core;
using BuilderPattern.Models;

namespace BuilderPattern.Builders;

public class ConcreteHouseBuilder(UserPreferences preferences) : IHouseBuilder
{
    private const int MAX_DOORS = 15;
    private const int STANDARD_DOORS = 7;
    private const int MIN_DOORS = 2;

    private const int MAX_FLOORS = 5;
    private const int STANDARD_FLOORS = 3;
    private const int MIN_FLOORS = 1;

    private const int MAX_ROOMS = 5;
    private const int STANDARD_ROOMS = 3;
    private const int MIN_ROOMS = 2;

    private const int MAX_BATHROOMS = 2;
    private const int STANDARD_BATHROOMS = 1;
    private const int MIN_BATHROOMS = 1;

    private readonly string _wallType = "concrete";
    private readonly string _roofType = "concrete";
    private readonly string _doorType = "concrete";
    private readonly string _doorColor = "gray";
    private readonly string _floorColor = "gray";
    private readonly string _wallColor = "gray";

    private Count? _doorsCount;
    private Count? _floorsCount;
    private Count? _roomsPerFloor;
    private Count? _bathRoomsPerFloor;

    private readonly UserPreferences _preferences;

    public void AddDoors(Count count) => _doorsCount = count;

    public void AddFloors(Count count) => _floorsCount = count;

    public void AddRooms(Count countPerFloor) => _roomsPerFloor = countPerFloor;

    public void AddBathrooms(Count countPerFloor) => _bathRoomsPerFloor = countPerFloor;

    public House BuildHouse()
    {
        var floorsCount = _floorsCount switch
        {
            Count.Max => MAX_FLOORS,
            Count.Medium => STANDARD_FLOORS,
            Count.Min => MIN_FLOORS,
            _ => throw new ArgumentOutOfRangeException(nameof(_floorsCount))
        };
        var roomsPerFloor = _roomsPerFloor switch
        {
            Count.Max => MAX_ROOMS,
            Count.Medium => STANDARD_ROOMS,
            Count.Min => MIN_ROOMS,
            _ => throw new ArgumentOutOfRangeException(nameof(_roomsPerFloor))
        };
        var bathRoomsPerFloor = _bathRoomsPerFloor switch
        {
            Count.Max => MAX_BATHROOMS,
            Count.Medium => STANDARD_BATHROOMS,
            Count.Min => MIN_BATHROOMS,
            _ => throw new ArgumentOutOfRangeException(nameof(_bathRoomsPerFloor))
        };

        return new()
        {
            DoorsCount = _doorsCount switch
            {
                Count.Max => MAX_DOORS,
                Count.Medium => STANDARD_DOORS,
                Count.Min => MIN_DOORS,
                _ => throw new ArgumentOutOfRangeException(nameof(_doorsCount))
            },
            WallType = _wallType,
            RoofType = _roofType,
            DoorType = _doorType,
            DoorColor = _doorColor,
            FloorColor = _floorColor,
            WallColor = _wallColor,
            FloorsCount = floorsCount,
            RoomsCount = roomsPerFloor * floorsCount,
            BathroomsCount = bathRoomsPerFloor * floorsCount
        };
    }
}
