using FactoryPattern.Core;

namespace FactoryPattern.Senders;

public class MobileNotificationSender : ISender
{
    public void Send(string message)
    {
        Console.WriteLine("Sent a mobile notification to the user with message: {0}", message);
    }
}
