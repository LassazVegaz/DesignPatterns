namespace BridgePattern.Models;

public record User
{
    public string Name { get; set; } = null!;
    public int Age { get; set; }
    public string JobTitle { get; set; } = null!;
}
