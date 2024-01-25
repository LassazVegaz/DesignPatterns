using AbstractFactoryPattern.Core;

namespace AbstractFactoryPattern.Generators;

public class OfflineWordsGenerator(string dataSource) : IReportGenerator
{
    public string GenerateReport()
    {
        Console.WriteLine($"Generating a word report on C drive using {dataSource}");
        Console.WriteLine($"Generated the word report on C drive using {dataSource}");
        return "C:/reports/report.docx";
    }
}
