using DecoratorPattern;
using DecoratorPattern.Core;
using DecoratorPattern.Toppings;

static ChickenType ShowChickenMenu()
{
    Console.WriteLine("Select chicken type:");
    Console.WriteLine("1. BBQ");
    Console.WriteLine("2. Tandoori");
    Console.WriteLine("3. Devilled");
    Console.Write("Enter choice: ");
    var choice = Console.ReadLine();

    return choice switch
    {
        "1" => ChickenType.BBQ,
        "2" => ChickenType.Tandoori,
        "3" => ChickenType.Devilled,
        _ => throw new ArgumentException("Invalid choice")
    };
}

static ChickenTopping CreateChickenTopping()
{
    var chickenType = ShowChickenMenu();
    return new ChickenTopping(chickenType);
}

static CheeseTopping CreateCheeseTopping() => new();

var toppingsCreatorMap = new Dictionary<string, Func<ITopping>>
{
    ["1"] = CreateCheeseTopping,
    ["2"] = CreateChickenTopping
};

Console.WriteLine("Welcome to Pizza Palace");
Console.WriteLine("Select your pizza toppings");
Console.WriteLine("1. Cheese");
Console.WriteLine("2. Chicken");
Console.Write("Enter choice seperated by spaces: ");

var choices = Console.ReadLine()?.Trim().Split(' ');
string[] validChoices = ["1", "2"];
if (choices == null || choices.Any(c => !validChoices.Contains(c)))
{
    Console.WriteLine("Invalid choice");
    return;
}

var pizza = new Pizza();

for (var i = 0; i < choices.Length; i++)
{
    ITopping topping;
    try
    {
        topping = toppingsCreatorMap[choices[i]]();
    }
    catch (Exception)
    {
        Console.WriteLine("Invalid choice");
        return;
    }

    pizza.AddTopping(topping);
}

Console.WriteLine($"\nTotal cost: {pizza.GetCost():c}");