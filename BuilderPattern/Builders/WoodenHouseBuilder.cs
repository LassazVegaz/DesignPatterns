using BuilderPattern.Core;
using BuilderPattern.Models;

namespace BuilderPattern.Builders;

public class WoodenHouseBuilder(UserPreferences preferences) : IHouseBuilder
{
    private const int MAX_DOORS = 10;
    private const int STANDARD_DOORS = 4;
    private const int MIN_DOORS = 1;

    private const int MAX_FLOORS = 3;
    private const int STANDARD_FLOORS = 2;
    private const int MIN_FLOORS = 1;

    private const int MAX_ROOMS = 4;
    private const int STANDARD_ROOMS = 2;
    private const int MIN_ROOMS = 1;

    private const int MAX_BATHROOMS = 2;
    private const int STANDARD_BATHROOMS = 1;
    private const int MIN_BATHROOMS = 1;

    private readonly string _wallType = "wooden";
    private readonly string _roofType = "wooden";
    private readonly string _doorType = "wooden";
    private readonly string _doorColor = "brown";
    private readonly string _floorColor = "brown";
    private readonly string _wallColor = "brown";

    private Count? _doorsCount;
    private Count? _floorsCount;
    private Count? _roomsPerFloor;
    private Count? _bathRoomsPerFloor;

    private readonly UserPreferences _preferences = preferences;

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
        var bathroomsPerFloor = _bathRoomsPerFloor switch
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
            FloorsCount = floorsCount,
            RoomsCount = floorsCount * roomsPerFloor,
            BathroomsCount = floorsCount * bathroomsPerFloor,
            DoorColor = _preferences.DarkColor ?? _doorColor,
            DoorType = _doorType,
            FloorColor = _preferences.LightColor ?? _floorColor,
            WallColor = _preferences.MainColor ?? _wallColor,
            WallType = _wallType,
            RoofType = _roofType
        };
    }
}
