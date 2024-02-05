using ChainOfResponsibilityPattern.Core;
using ChainOfResponsibilityPattern.Models;

namespace ChainOfResponsibilityPattern.Handlers;

internal class BooksEndpointHandler(IUsersRepository usersRepository) : Handler
{
    private readonly IUsersRepository _usersRepo = usersRepository;


    public BooksEndpointHandler(IUsersRepository usersRepository, IHandler nextHandler) : this(usersRepository)
    {
        next = nextHandler;
    }

    public override Response Handle(Request request)
    {
        var books = _usersRepo.GetUsers().First(u => u.Id == request.UserId).Books;
        return new() { Data = books };
    }
}
