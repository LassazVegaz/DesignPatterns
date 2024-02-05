namespace ChainOfResponsibilityPattern.Models;

internal record User
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Role { get; set; } = null!;
    public List<string> Books { get; set; } = [];
}
