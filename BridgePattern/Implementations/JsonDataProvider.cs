using BridgePattern.Core;
using BridgePattern.Models;
using System.Text.Json;

namespace BridgePattern.Implementations;

public class JsonDataProvider : IDataProvider
{
    private const string FILE_NAME = "users.json";

    public IEnumerable<User> GetUsers()
    {
        var json = File.ReadAllText(FILE_NAME);
        var users = JsonSerializer.Deserialize<User[]>(json);
        return users ?? [];
    }
}
