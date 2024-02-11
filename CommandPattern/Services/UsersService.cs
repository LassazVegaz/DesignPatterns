using CommandPattern.Core;
using CommandPattern.Models;

namespace CommandPattern.Services;

internal class UsersService : IUsersService
{
    private const string USERS_FILE = "users.txt";


    public UsersService()
    {
        if (!File.Exists(USERS_FILE))
        {
            File.Create(USERS_FILE).Close();
        }
    }

    public void AddUser(string email, string name)
    {
        var id = GetNextId();
        using var writer = new StreamWriter(USERS_FILE, append: true);
        writer.WriteLine($"{id},{email},{name}");
    }

    public void RemoveUser(int id)
    {
        var newUsers = File.ReadAllLines(USERS_FILE).Where(u => int.Parse(u.Split(',')[0]) != id);
        File.WriteAllLines(USERS_FILE, newUsers);
    }

    public IEnumerable<User> GetUsers()
    {
        var users = File.ReadAllLines(USERS_FILE).Select(u =>
        {
            var parts = u.Split(',');
            return new User
            {
                Id = int.Parse(parts[0]),
                Email = parts[1],
                Name = parts[2]
            };
        });
        return users;
    }

    private int GetNextId()
    {
        var lines = File.ReadAllLines(USERS_FILE);
        if (lines.Length == 0) return 1;

        return int.Parse(File.ReadAllLines(USERS_FILE).Last().Split(',')[0]) + 1;
    }
}
