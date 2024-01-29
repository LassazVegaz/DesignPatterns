using PrototypePattern.Models;

namespace PrototypePattern;

public enum VehicleType
{
    Luxury = 1,
    Semi,
    Standard,
}

public class VehicleRegistry
{
    public static readonly VehicleRegistry instance = new();

    private readonly Dictionary<VehicleType, Car> cars = new()
    {
        { VehicleType.Luxury, new() { Doors = 2, Engine = 2000, FuelCap = 50.0, HasSunRoof = true, Name = "Lamborghini", Seats = 2, Type = "Huracan", Wheels = 4 } },
        { VehicleType.Semi, new() { Doors = 4, Engine = 1500, FuelCap = 45.0, HasSunRoof = false, Name = "V8", Seats = 2, Type = "Ford", Wheels = 4 } },
        { VehicleType.Standard, new() { Doors = 4, Engine = 1000, FuelCap = 30.0, HasSunRoof = false, Name = "Suzuki", Seats = 4, Type = "Alto", Wheels = 4 } },
    };

    private readonly Dictionary<VehicleType, Van> vans = new()
    {
        { VehicleType.Luxury, new() { Doors = 4, Engine = 2500, FuelCap = 70.0, Name = "Toyota", Seats = 2, Type = "ALPHARD", Wheels = 4, HasSlidingDoors = true } },
        { VehicleType.Semi, new() { Doors = 4, Engine = 1000, FuelCap = 50.0, Name = "Mercedes-Benz", Seats = 2, Type = "Vito", Wheels = 4, HasSlidingDoors = true } },
        { VehicleType.Standard, new() { Doors = 4, Engine = 1000, FuelCap = 30.0, Name = "Toyota", Seats = 4, Type = "KDH", Wheels = 4, HasSlidingDoors = false } },
    };

    private readonly Dictionary<VehicleType, Bike> bikes = new()
    {
        { VehicleType.Luxury, new() { Engine = 1000, FuelCap = 70.0, Name = "Honda", Seats = 2, Type = "Goldwing", Wheels = 2, HasReverseGear = true, HasSideCar = true } },
        { VehicleType.Semi, new() { Engine = 500, FuelCap = 50.0, Name = "Bajaj", Seats = 2, Type = "Pulsar", Wheels = 2, HasReverseGear = true, HasSideCar = false } },
        { VehicleType.Standard, new() { Engine = 100, FuelCap = 30.0, Name = "Honda", Seats = 4, Type = "CD100", Wheels = 2, HasReverseGear = false, HasSideCar = false } },
    };


    private VehicleRegistry() { }


    public Car GetCar(VehicleType vehicleType) => (Car)cars[vehicleType].Clone();
    public Van GetVan(VehicleType vehicleType) => (Van)vans[vehicleType].Clone();
    public Bike GetBike(VehicleType vehicleType) => (Bike)bikes[vehicleType].Clone();
}
