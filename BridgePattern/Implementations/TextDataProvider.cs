using BridgePattern.Core;
using BridgePattern.Models;

namespace BridgePattern.Implementations;

public class TextDataProvider : IDataProvider
{
    private const string FILE_NAME = "users.txt";
    private const string SEPERATOR = "|";

    public IEnumerable<User> GetUsers()
    {
        var users = File.ReadAllLines(FILE_NAME).Select(line =>
        {
            var parts = line.Split(SEPERATOR);
            return new User
            {
                Name = parts[0],
                Age = int.Parse(parts[1]),
                JobTitle = parts[2]
            };
        });

        return users;
    }
}
