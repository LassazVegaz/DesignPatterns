using ChainOfResponsibilityPattern.Models;

namespace ChainOfResponsibilityPattern.Core;

internal interface IUsersRepository
{
    IEnumerable<User> GetUsers();
}
