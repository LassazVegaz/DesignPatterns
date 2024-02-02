using DecoratorPattern.Core;

namespace DecoratorPattern.Toppings;

internal abstract class ToppingBase : ITopping
{
    private ITopping? _topping;


    public void AddTopping(ITopping topping)
    {
        if (_topping is not null)
            _topping.AddTopping(topping);
        else
            _topping = topping;
    }

    public virtual double GetCost()
    {
        return _topping?.GetCost() ?? 0;
    }
}
