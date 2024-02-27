using MediatorPattern.Components;
using MediatorPattern.Services;

namespace MediatorPattern;

internal class Mediator
{
    public void GetData()
    {
        var storageService = new StorageService();
        var userNameComp = new TextComponent { Label = "Enter your name: " };
        var ageComp = new NumericalComponent { Label = "Enter your age: " };

        userNameComp.OnError += OnError;
        ageComp.OnError += OnError;

        userNameComp.OnUserNameChanged += (sender, e) =>
        {
            storageService.Save("name", e);
            ageComp.Display();
        };

        ageComp.OnUserNameChanged += (sender, e) =>
        {
            storageService.Save("age", e.ToString());
            Console.WriteLine("\nData saved successfully");
        };

        userNameComp.Display();
    }

    private void OnError(object? sender, EventArgs e)
    {
        Console.WriteLine("\nInvalid input");
    }
}
