using ChainOfResponsibilityPattern.Core;
using ChainOfResponsibilityPattern.Models;

namespace ChainOfResponsibilityPattern;

internal class UsersRepository : IUsersRepository
{
    private readonly User[] users = [
        new User()
        {
            Id = 1,
            Email = "john@gmail.com",
            Password = "john@1234",
            Role = "customer",
            Books = ["Harry Porter", "A-Team", "ABCD"]
        },
        new User()
        {
            Id = 2,
            Email = "bob@gmail.com",
            Password = "bob@1234",
            Role = "customer",
            Books = ["James Bond", "Harry Porter"]
        },
        new User()
        {
            Id = 3,
            Email = "hiru@gmail.com",
            Password = "hiru@1234",
            Role = "pending customer"
        },
    ];

    public IEnumerable<User> GetUsers() => users;
}
