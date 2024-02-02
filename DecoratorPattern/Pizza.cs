using DecoratorPattern.Core;

namespace DecoratorPattern;

internal class Pizza
{
    private ITopping? _topping;


    public void AddTopping(ITopping topping)
    {
        if (_topping is not null)
            _topping.AddTopping(topping);
        else
            _topping = topping;
    }

    public double GetCost()
    {
        var toppingCost = _topping?.GetCost() ?? 0;
        return 5 + toppingCost;
    }
}
