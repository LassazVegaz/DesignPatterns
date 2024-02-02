namespace DecoratorPattern.Toppings;

internal class CheeseTopping : ToppingBase
{
    public override double GetCost() => base.GetCost() + 0.5;
}
