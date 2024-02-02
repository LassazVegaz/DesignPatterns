namespace DecoratorPattern.Toppings;

internal enum ChickenType
{
    BBQ,
    Tandoori,
    Devilled
}

internal class ChickenTopping(ChickenType type) : ToppingBase
{
    private readonly ChickenType _type = type;
    private readonly Dictionary<ChickenType, double> _costMapping = new()
    {
        { ChickenType.BBQ, 1.5 },
        { ChickenType.Tandoori, 2.0 },
        { ChickenType.Devilled, 2.5 }
    };

    public override double GetCost() => base.GetCost() + _costMapping[_type];
}
