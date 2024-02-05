namespace ChainOfResponsibilityPattern.Models;

internal class Request
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public int UserId { get; set; }
}
