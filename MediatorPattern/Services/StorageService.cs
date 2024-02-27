namespace MediatorPattern.Services;

internal class StorageService
{
    private const string FILE = "storage.txt";

    public StorageService()
    {
        if (!File.Exists(FILE))
            File.Create(FILE).Close();
    }

    public void Save(string key, string data)
    {
        var storage = GetData();
        storage[key] = data;
        SaveData(storage);
    }

    private Dictionary<string, string> GetData()
    {
        var lines = File.ReadAllLines(FILE);
        var data = new Dictionary<string, string>();
        foreach (var line in lines)
        {
            var parts = line.Split("=");
            data.Add(parts[0], parts[1]);
        }
        return data;
    }

    private void SaveData(Dictionary<string, string> data)
    {
        var lines = data.Select(x => $"{x.Key}={x.Value}");
        File.WriteAllLines(FILE, lines);
    }
}
