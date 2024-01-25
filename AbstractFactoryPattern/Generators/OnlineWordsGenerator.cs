using AbstractFactoryPattern.Core;

namespace AbstractFactoryPattern.Generators;

public class OnlineWordsGenerator(string dataSource) : IReportGenerator
{
    public string GenerateReport()
    {
        Console.WriteLine($"Generating a word report on Google drive using {dataSource}");
        Console.WriteLine($"Generated the word report on Google drive using {dataSource}");
        return "https://drive.google.com/report.docx";
    }
}
