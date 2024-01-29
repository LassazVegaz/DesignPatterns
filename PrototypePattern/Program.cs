using PrototypePattern;
using PrototypePattern.Models;

string[] validInputTypes = ["1", "2", "3"];

Console.WriteLine("Please select the vehicle type you want");
Console.WriteLine("1. Car");
Console.WriteLine("2. Van");
Console.WriteLine("3. Bike");
Console.Write("Please enter the number: ");
var vehicleType = Console.ReadLine();
if (!validInputTypes.Contains(vehicleType))
{
    Console.WriteLine("Invalid input");
    return;
}

Console.WriteLine("\nPlease select the vehicle luxury type you want");
Console.WriteLine("1. Luxury");
Console.WriteLine("2. Semi-Luxury");
Console.WriteLine("3. Standard");
Console.Write("Please enter the number: ");
var vehicleLuxuryTypeStr = Console.ReadLine();
if (!validInputTypes.Contains(vehicleLuxuryTypeStr))
{
    Console.WriteLine("Invalid input");
    return;
}
var vehicleLuxuryType = (VehicleType)int.Parse(vehicleLuxuryTypeStr!);

Vehicle vehicle = vehicleType switch
{
    "1" => VehicleRegistry.instance.GetCar(vehicleLuxuryType),
    "2" => VehicleRegistry.instance.GetVan(vehicleLuxuryType),
    "3" => VehicleRegistry.instance.GetBike(vehicleLuxuryType),
    _ => throw new(),
};

Console.WriteLine("\nThe vehicle we brought for you,");
vehicle.Describe();