using CommandPattern.Core;
using CommandPattern.Models;

namespace CommandPattern.Commands;

internal class CreateUserCommand(IUsersService usersService) : Command
{
    private string? email;
    public string Email { set => email = value; }

    private string? name;
    public string Name { set => name = value; }

    override public void Execute()
    {
        var _email = email ?? appState?.UserEnteredEmail ?? throw new ArgumentNullException(nameof(AppState));
        var _name = name ?? appState?.UserEnteredName ?? throw new ArgumentNullException(nameof(AppState));
        usersService.AddUser(_email, _name);

        if (history != null)
        {
            var users = usersService.GetUsers();
            var id = users.Last().Id;
            var undoCommand = new DeleteUserCommand(usersService) { UserId = id };
            history.Add(undoCommand);
        }
    }
}
