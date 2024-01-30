using AdapterPattern.Adapters;
using AdapterPattern.Core;
using AdapterPattern.Legacy;

static void PrintUsers(IUsersService usersService)
{
    var users = usersService.GetUsers();
    var idx = 0;
    foreach (var user in users)
    {
        idx++;
        Console.WriteLine($"User {idx}: {user.Name} - {user.Age} - {user.JobTitle}");
    }
}

var legacyShit = new UsersDAO("users.txt");
var adapter = new UsersDAOAdapter(legacyShit);
PrintUsers(adapter);