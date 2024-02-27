namespace MediatorPattern.Components;

internal class NumericalComponent
{
    public required string Label { get; set; }

    public event EventHandler<int>? OnUserNameChanged;
    public event EventHandler? OnError;

    public void Display()
    {
        Console.WriteLine(Label);
        var userName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(userName) || !int.TryParse(userName, out int input))
            OnError?.Invoke(this, EventArgs.Empty);
        else
            OnUserNameChanged?.Invoke(this, input);
    }
}
