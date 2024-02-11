using CommandPattern.Models;

namespace CommandPattern.Core;

internal interface IUsersService
{
    void AddUser(string email, string name);
    IEnumerable<User> GetUsers();
    void RemoveUser(int id);
}