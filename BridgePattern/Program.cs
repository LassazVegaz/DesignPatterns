using BridgePattern.Abstractions;
using BridgePattern.Core;
using BridgePattern.Implementations;

static void Main(IDataPrinter printer)
{
    Console.WriteLine("Users:\n\n");
    printer.PrintData();
}

IDataProvider provider = Random.Shared.Next(0, 2) switch
{
    0 => new JsonDataProvider(),
    1 => new TextDataProvider(),
    _ => throw new NotImplementedException()
};
IDataPrinter printer = Random.Shared.Next(0, 2) switch
{
    0 => new StandardDataPrinter(provider),
    1 => new TableDataPrinter(provider),
    _ => throw new NotImplementedException()
};

Main(printer);