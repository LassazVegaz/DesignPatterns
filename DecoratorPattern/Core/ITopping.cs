namespace DecoratorPattern.Core;

internal interface ITopping
{
    /// <summary>
    /// Add a topping on top of this topping
    /// </summary>
    void AddTopping(ITopping topping);

    double GetCost();
}
