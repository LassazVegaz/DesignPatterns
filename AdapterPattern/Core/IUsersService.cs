using AdapterPattern.Models;

namespace AdapterPattern.Core;

public interface IUsersService
{
    IEnumerable<User> GetUsers();
}
