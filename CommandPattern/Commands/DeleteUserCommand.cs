using CommandPattern.Core;
using CommandPattern.Models;

namespace CommandPattern.Commands;

internal class DeleteUserCommand(IUsersService usersService) : Command
{
    private int? userId;
    public int UserId { set => userId = value; }

    override public void Execute()
    {
        var _userId = userId ?? appState?.UserEnteredId ?? throw new ArgumentNullException(nameof(AppState));

        if (history != null)
        {
            var users = usersService.GetUsers();
            var user = users.First(u => u.Id == _userId);
            var undoCommand = new CreateUserCommand(usersService) { Email = user.Email, Name = user.Name };
            history.Add(undoCommand);
        }

        usersService.RemoveUser(_userId);
    }
}
