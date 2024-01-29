using PrototypePattern.Core;

namespace PrototypePattern.Models;

abstract public class Vehicle : ICloner
{
    public string Name { get; set; } = null!;
    public string Type { get; set; } = null!;
    public int Wheels { get; set; }
    public int Seats { get; set; }
    public int Engine { get; set; }
    public double FuelCap { get; set; }


    public Vehicle() { }

    public Vehicle(Vehicle vehicle)
    {
        Name = vehicle.Name;
        Type = vehicle.Type;
        Wheels = vehicle.Wheels;
        Seats = vehicle.Seats;
        Engine = vehicle.Engine;
        FuelCap = vehicle.FuelCap;
    }


    public abstract ICloner Clone();

    public virtual void Describe()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Type: {Type}");
        Console.WriteLine($"Wheels: {Wheels}");
        Console.WriteLine($"Seats: {Seats}");
        Console.WriteLine($"Engine: {Engine} CC");
        Console.WriteLine($"Fuel capacity: {FuelCap} L");
    }
}
