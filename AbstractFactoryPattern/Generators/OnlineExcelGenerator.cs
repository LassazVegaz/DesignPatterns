using AbstractFactoryPattern.Core;

namespace AbstractFactoryPattern.Generators;

public class OnlineExcelGenerator(string dataSource) : IReportGenerator
{
    public string GenerateReport()
    {
        Console.WriteLine($"Generating an excel report on Google drive using {dataSource}");
        Console.WriteLine($"Generated the excel report on Google drive using {dataSource}");
        return "https://drive.google.com/report.xlsx";
    }
}
