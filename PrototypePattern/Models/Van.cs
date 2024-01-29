using PrototypePattern.Core;

namespace PrototypePattern.Models;

public class Van : Vehicle
{
    public bool HasSlidingDoors { get; set; }
    public int Doors { get; set; }


    public Van()
    {
        Wheels = 4;
    }

    public Van(Van van) : base(van)
    {
        HasSlidingDoors = van.HasSlidingDoors;
        Doors = van.Doors;
    }


    override public ICloner Clone() => new Van(this);

    public override void Describe()
    {
        base.Describe();
        Console.WriteLine($"Has sliding doors: {HasSlidingDoors}");
        Console.WriteLine($"Doors: {Doors}");
    }
}
