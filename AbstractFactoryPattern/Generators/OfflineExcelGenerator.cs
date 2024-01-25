using AbstractFactoryPattern.Core;

namespace AbstractFactoryPattern.Generators;

public class OfflineExcelGenerator(string dataSource) : IReportGenerator
{
    public string GenerateReport()
    {
        Console.WriteLine($"Generating an excel report on C drive using {dataSource}");
        Console.WriteLine($"Generated the excel report on C drive using {dataSource}");
        return "C:/reports/report.xlsx";
    }
}
