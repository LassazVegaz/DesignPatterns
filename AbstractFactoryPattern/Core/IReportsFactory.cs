namespace AbstractFactoryPattern.Core;

public interface IReportsFactory
{
    IReportGenerator CreateReportGenerator(string dataSource);
}
