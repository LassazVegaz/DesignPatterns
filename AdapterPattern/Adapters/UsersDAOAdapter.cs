using AdapterPattern.Core;
using AdapterPattern.Legacy;
using AdapterPattern.Models;

namespace AdapterPattern.Adapters;

public class UsersDAOAdapter(UsersDAO usersDAO) : IUsersService
{
    private readonly UsersDAO _usersDAO = usersDAO;


    public IEnumerable<User> GetUsers()
    {
        if (!File.Exists(_usersDAO.DataSource)) return [];

        return _usersDAO.GetUsers().Select(user => new User
        {
            Name = user[0],
            Age = int.Parse(user[1]),
            JobTitle = user[2]
        });
    }
}
