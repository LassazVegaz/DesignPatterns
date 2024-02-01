using CompositePattern.Core;

namespace CompositePattern;
internal class Main
{
    const double PROFIT_MARGIN = 0.2;
    const double TAX = 0.1;

    public static void Run(ICostObject item)
    {
        Console.WriteLine("Calculating total price for your item(s)....");
        var price = item.CalculateCost() * (1 + PROFIT_MARGIN) * (1 + TAX);
        Console.WriteLine($"Total price: {price:c}");
    }
}
