namespace MementoPattern;

internal class Snapshot(Database database)
{
    public readonly IReadOnlyList<string> users = database.users.ToList();
    public readonly IReadOnlyList<string> companies = database.companies.ToList();
    public readonly Database database = database;

    public void Restore()
    {
        database.users.Clear();
        database.users.AddRange(users);

        database.companies.Clear();
        database.companies.AddRange(companies);
    }
}
