using AbstractFactoryPattern.Core;
using AbstractFactoryPattern.Factories;

static void Run(IReportsFactory reportsFactory)
{
    Console.Write("To generate your report, please enter the data source: ");

    var dataSource = Console.ReadLine();
    if (string.IsNullOrEmpty(dataSource))
    {
        Console.WriteLine("Data source cannot be empty.");
        return;
    }

    var reportsGenerator = reportsFactory.CreateReportGenerator(dataSource);
    var reportLink = reportsGenerator.GenerateReport();

    Console.WriteLine($"Your report is ready. You can get it from {reportLink}");
}

static bool IsGoogleDriveConnected()
{
    return new Random().Next(0, 2) == 1;
}

IReportsFactory reportsFactory = IsGoogleDriveConnected() ? new OnlineReportsFactory() : new OfflineReportsFactory();
Run(reportsFactory);
