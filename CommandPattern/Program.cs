using CommandPattern.Commands;
using CommandPattern.Core;
using CommandPattern.Models;
using CommandPattern.Services;

var state = new AppState();
var history = new List<ICommand>();
var usersService = new UsersService();
var commands = new Dictionary<int, ICommand>
{
    [1] = new CreateUserCommand(usersService)
    {
        AppState = state,
        CommandsHistory = history
    },
    [2] = new DeleteUserCommand(usersService)
    {
        AppState = state,
        CommandsHistory = history
    }
};

static void ShowMenu(List<ICommand> history)
{
    Console.WriteLine("Following commands are available");
    Console.WriteLine("0. Quite");
    Console.WriteLine("1. Create user");
    Console.WriteLine("2. Delete user");
    if (history.Count != 0) Console.WriteLine("3. Undo");
    Console.Write("Enter command number: ");
}

static void MenuOp1(AppState appState, ICommand command)
{
    Console.Write("Enter user name: ");
    var name = Console.ReadLine();
    if (string.IsNullOrEmpty(name))
    {
        Console.WriteLine("Name cannot be empty");
        return;
    }

    Console.Write("Enter user email: ");
    var email = Console.ReadLine();
    if (string.IsNullOrEmpty(email))
    {
        Console.WriteLine("Email cannot be empty");
        return;
    }

    appState.UserEnteredName = name;
    appState.UserEnteredEmail = email;
    command.Execute();

    Console.WriteLine("User created");
}

static void MenuOp2(AppState appState, ICommand command)
{
    Console.Write("Enter user ID: ");
    var idStr = Console.ReadLine();
    if (!int.TryParse(idStr, out var id))
    {
        Console.WriteLine("Invalid ID");
        return;
    }

    appState.UserEnteredId = id;
    command.Execute();

    Console.WriteLine("User deleted");
}

var menuOps = new Dictionary<int, MenuOp>
{
    [1] = MenuOp1,
    [2] = MenuOp2
};

while (true)
{
    Console.WriteLine();
    ShowMenu(history);
    if (!int.TryParse(Console.ReadLine(), out var commandNumber))
    {
        Console.WriteLine("Invalid command number");
        continue;
    }
    Console.WriteLine();

    if (commandNumber == 0) break;

    if (commandNumber == 3)
    {
        history[^1].Execute();
        history.RemoveAt(history.Count - 1);
        continue;
    }

    if (!commands.ContainsKey(commandNumber))
    {
        Console.WriteLine("Invalid command number");
        continue;
    }

    var command = commands[commandNumber];
    menuOps[commandNumber](state, command);
}


delegate void MenuOp(AppState appState, ICommand command);