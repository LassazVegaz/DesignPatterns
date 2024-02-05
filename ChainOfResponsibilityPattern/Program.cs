using ChainOfResponsibilityPattern;
using ChainOfResponsibilityPattern.Core;
using ChainOfResponsibilityPattern.Handlers;

var usersRepo = new UsersRepository();
IHandler handler = new BooksEndpointHandler(usersRepo);
handler = new AuthorizationHandler(["customer"], usersRepo, handler);
handler = new AuthenticationHandler(usersRepo, handler);
handler = new ExceptionsHandler(handler);

Main.Run(handler);
