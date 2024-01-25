using AbstractFactoryPattern.Core;
using AbstractFactoryPattern.Generators;

namespace AbstractFactoryPattern.Factories;

public class OnlineReportsFactory : IReportsFactory
{
    private bool IsSourceTable(string dataSource)
    {
        var rndVal = new Random().Next(1, dataSource.Length);
        return rndVal % 2 == 0;
    }

    public IReportGenerator CreateReportGenerator(string dataSource)
    {
        if (IsSourceTable(dataSource))
            return new OnlineExcelGenerator(dataSource);
        else
            return new OnlineWordsGenerator(dataSource);
    }
}
