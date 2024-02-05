using ChainOfResponsibilityPattern.Core;
using ChainOfResponsibilityPattern.Models;

namespace ChainOfResponsibilityPattern.Handlers;

internal class AuthenticationHandler(IUsersRepository usersRepository) : Handler
{
    private readonly IUsersRepository _usersRepo = usersRepository;


    public AuthenticationHandler(IUsersRepository usersRepository, IHandler nextHandler) : this(usersRepository)
    {
        next = nextHandler;
    }

    public override Response Handle(Request request)
    {
        var user = _usersRepo.GetUsers().FirstOrDefault(u => u.Email == request.Email);

        if (user == null)
            throw new("Email does not exist");
        else if (user.Password != request.Password)
            throw new("Invalid password");
        else
        {
            request.UserId = user.Id;
            return next?.Handle(request) ?? new();
        }
    }
}
