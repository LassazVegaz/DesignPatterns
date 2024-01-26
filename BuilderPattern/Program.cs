using BuilderPattern;
using BuilderPattern.Builders;
using BuilderPattern.Core;
using BuilderPattern.Models;

var preferences = new UserPreferences
{
    DarkColor = "black",
    LightColor = "white",
    MainColor = "dark blue",
};

Console.WriteLine("We need more info about house you want...\n");
Console.WriteLine("1 - Standard");
Console.WriteLine("2 - Medium");
Console.WriteLine("3 - Luxury");
Console.Write("Please select the luxury level: ");
var luxuryLevelStr = Console.ReadLine();
if (string.IsNullOrEmpty(luxuryLevelStr))
{
    Console.WriteLine("Invalid luxury level");
    return;
}
var luxuryLevel = (LuxuryLevel)(int.Parse(luxuryLevelStr) - 1);

Console.WriteLine();
Console.WriteLine("1 - Wooden");
Console.WriteLine("2 - Concrete");
Console.Write("Please select the house type: ");
var houseType = Console.ReadLine();
if (string.IsNullOrEmpty(houseType))
{
    Console.WriteLine("Invalid house type");
    return;
}

IHouseBuilder builder = houseType switch
{
    "1" => new WoodenHouseBuilder(preferences),
    "2" => new ConcreteHouseBuilder(preferences),
    _ => throw new ArgumentException("Invalid house type"),
};
var architect = new HouseArchitect(builder, luxuryLevel);
var house = architect.BuildHouse();

Console.WriteLine();
house.Print();