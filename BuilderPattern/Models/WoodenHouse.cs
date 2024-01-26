namespace BuilderPattern.Models;

public class House
{
    public required int RoomsCount { get; set; }
    public required int BathroomsCount { get; set; }
    public required int FloorsCount { get; set; }
    public required int DoorsCount { get; set; }
    public required string WallColor { get; set; }
    public required string FloorColor { get; set; }
    public required string DoorColor { get; set; }
    public required string DoorType { get; set; }
    public required string WallType { get; set; }
    public required string RoofType { get; set; }

    public void Print()
    {
        Console.WriteLine($"Your house has,");
        Console.WriteLine($"{RoomsCount} room{(RoomsCount > 0 ? "s" : "")},");
        Console.WriteLine($"{BathroomsCount} bathroom{(BathroomsCount > 0 ? "s" : "")},");
        Console.WriteLine($"{FloorsCount} floor{(FloorsCount > 0 ? "s" : "")},");
        Console.WriteLine($"{DoorsCount} {DoorColor} {DoorType} door{(DoorsCount > 0 ? "s" : "")}.");
        Console.WriteLine($"The walls are {WallColor} and {WallType}. The floor is {FloorColor}.");
    }
}
