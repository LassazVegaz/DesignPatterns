using MementoPattern;

Stack<Snapshot> snapshots = [];
var database = new Database();

while (true)
{
    Console.WriteLine();
    Console.WriteLine("0. Quite");
    Console.WriteLine("1. Add user");
    Console.WriteLine("2. Add company");
    Console.WriteLine("3. Show data");
    if (snapshots.Count > 0) Console.WriteLine("4. Undo");
    Console.Write("Select an option from the above list: ");

    List<string> validOptions = ["0", "1", "2", "3"];
    if (snapshots.Count > 0) validOptions.Add("4");

    var selectedOption = Console.ReadLine();
    Console.WriteLine();
    if (selectedOption == null || !validOptions.Contains(selectedOption))
    {
        Console.WriteLine("Invalid option");
        continue;
    }

    if (selectedOption == "0") break;

    if (selectedOption == "1")
    {
        Console.Write("Enter user name: ");
        var userName = Console.ReadLine();
        if (string.IsNullOrEmpty(userName))
        {
            Console.WriteLine("Invalid user name");
            continue;
        }

        // Take a snapshot before saving
        snapshots.Push(new(database));

        database.users.Add(userName);
    }

    else if (selectedOption == "2")
    {
        Console.Write("Enter company name: ");
        var companyName = Console.ReadLine();
        if (string.IsNullOrEmpty(companyName))
        {
            Console.WriteLine("Invalid company name");
            continue;
        }

        // Take a snapshot before saving
        snapshots.Push(new(database));

        database.companies.Add(companyName);
    }

    else if (selectedOption == "3")
    {
        Console.WriteLine("---Users:");
        foreach (var user in database.users)
        {
            Console.WriteLine(user);
        }

        Console.WriteLine("---Companies:");
        foreach (var company in database.companies)
        {
            Console.WriteLine(company);
        }
    }

    else if (selectedOption == "4")
    {
        if (snapshots.Count == 0)
        {
            Console.WriteLine("No snapshots available");
        }
        else
        {
            var lastSnapshot = snapshots.Pop();
            lastSnapshot.Restore();
            Console.WriteLine("Database restored");
        }
    }
}