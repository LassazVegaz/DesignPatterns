using ChainOfResponsibilityPattern.Core;
using ChainOfResponsibilityPattern.Models;

namespace ChainOfResponsibilityPattern;

internal class Main
{
    public static void Run(IHandler handler)
    {
        Console.WriteLine("Before retrieving books you need to login.");
        Console.Write("Please enter your email address: ");
        var email = Console.ReadLine();
        Console.Write("Please enter your password: ");
        var password = Console.ReadLine();
        Console.WriteLine();

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("Error: Email and password are required.");
            return;
        }

        var request = new Request
        {
            Email = email,
            Password = password
        };
        var res = handler.Handle(request);

        if (res.Data is Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
        else if (res.Data is IEnumerable<string> books)
        {
            Console.WriteLine($"Books: {string.Join(", ", books)}");
        }
        else
        {
            Console.WriteLine("An unknown error occurred.");
        }
    }
}
