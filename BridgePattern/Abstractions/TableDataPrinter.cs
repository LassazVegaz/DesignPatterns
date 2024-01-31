using BridgePattern.Core;

namespace BridgePattern.Abstractions;

public class TableDataPrinter(IDataProvider provider) : IDataPrinter
{
    private readonly IDataProvider _provider = provider;

    public void PrintData()
    {
        var headerName = MakeLengthy("Name", 20);
        Console.WriteLine($"{headerName}Age\tJob title");

        foreach (var user in _provider.GetUsers())
        {
            var name = MakeLengthy(user.Name, 20);
            Console.WriteLine($"{name}{user.Age}\t{user.JobTitle}");
        }

        Console.WriteLine();
    }

    private string MakeLengthy(string input, int length)
    {
        if (input.Length >= length)
        {
            return input;
        }

        return input + new string(' ', length - input.Length);
    }
}
