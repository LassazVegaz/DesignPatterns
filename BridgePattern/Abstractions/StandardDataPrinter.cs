using BridgePattern.Core;

namespace BridgePattern.Abstractions;

public class StandardDataPrinter(IDataProvider provider) : IDataPrinter
{
    private readonly IDataProvider _provider = provider;

    public void PrintData()
    {
        foreach (var user in _provider.GetUsers())
        {
            Console.WriteLine($"Name: {user.Name}");
            Console.WriteLine($"Age: {user.Age}");
            Console.WriteLine($"Job title: {user.JobTitle}");
            Console.WriteLine();
        }
    }
}
