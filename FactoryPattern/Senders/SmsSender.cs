using FactoryPattern.Core;

namespace FactoryPattern.Senders;

public class SmsSender(string phoneNumber) : ISender
{
    private readonly string _phoneNumber = phoneNumber;

    public void Send(string message)
    {
        Console.WriteLine("Sent a SMS to {0} with message: {1}", _phoneNumber, message);
    }
}
