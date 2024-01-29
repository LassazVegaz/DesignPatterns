using PrototypePattern.Core;

namespace PrototypePattern.Models;

public class Car : Vehicle
{
    public bool HasSunRoof { get; set; }
    public int Doors { get; set; }


    public Car()
    {
        Wheels = 4;
    }

    public Car(Car car) : base(car)
    {
        HasSunRoof = car.HasSunRoof;
        Doors = car.Doors;
    }


    override public ICloner Clone() => new Car(this);

    public override void Describe()
    {
        base.Describe();
        Console.WriteLine($"Has sun roof: {HasSunRoof}");
        Console.WriteLine($"Doors: {Doors}");
    }
}
