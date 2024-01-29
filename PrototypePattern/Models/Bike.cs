using PrototypePattern.Core;

namespace PrototypePattern.Models;

public class Bike : Vehicle
{
    public bool HasSideCar { get; set; }
    public bool HasReverseGear { get; set; }


    public Bike()
    {
        Seats = 1;
        Wheels = 2;
    }

    public Bike(Bike bike) : base(bike)
    {
        HasSideCar = bike.HasSideCar;
        HasReverseGear = bike.HasReverseGear;
    }


    override public ICloner Clone() => new Bike(this);

    public override void Describe()
    {
        base.Describe();
        Console.WriteLine($"Has side car: {HasSideCar}");
        Console.WriteLine($"Has reverse gear: {HasReverseGear}");
    }
}
