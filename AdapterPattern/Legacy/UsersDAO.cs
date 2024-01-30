namespace AdapterPattern.Legacy;

/// <summary>
/// A freakingly old data access object that returns data in a format that is not compatible with the rest of the application.
/// </summary>
/// <param name="dataSource">The text file containing user data</param>
public class UsersDAO(string dataSource)
{
    private const string SEPERATOR = "|";

    public string DataSource => dataSource;


    /// <summary>
    /// First element - name, second - age, third - job title
    /// Throw an exception if the data source is not found
    /// </summary>
    public IEnumerable<string[]> GetUsers() => File.ReadAllLines(DataSource).Select(line => line.Split(SEPERATOR));
}
