namespace MediatorPattern.Components;

internal class TextComponent
{
    public required string Label { get; set; }

    public event EventHandler<string>? OnUserNameChanged;
    public event EventHandler? OnError;

    public void Display()
    {
        Console.WriteLine(Label);
        var userName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(userName))
            OnError?.Invoke(this, EventArgs.Empty);
        else
            OnUserNameChanged?.Invoke(this, userName);
    }
}
