using ChainOfResponsibilityPattern.Core;
using ChainOfResponsibilityPattern.Models;

namespace ChainOfResponsibilityPattern.Handlers;

internal class AuthorizationHandler(string[] allowedRoles, IUsersRepository usersRepository) : Handler
{
    private readonly string[] _allowedRoles = allowedRoles;
    private readonly IUsersRepository _usersRepo = usersRepository;


    public AuthorizationHandler(string[] allowedRoles, IUsersRepository usersRepository, IHandler nextHandler)
        : this(allowedRoles, usersRepository)
    {
        next = nextHandler;
    }

    public override Response Handle(Request request)
    {
        var user = _usersRepo.GetUsers().First(u => u.Id == request.UserId);

        if (!_allowedRoles.Contains(user.Role)) throw new("Unauthorized user type");

        return next?.Handle(request) ?? new();
    }
}
