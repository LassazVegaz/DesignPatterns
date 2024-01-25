using FactoryPattern.Core;

namespace FactoryPattern.Senders;

public class DesktopNotificationSender : ISender
{
    public void Send(string message)
    {
        Console.WriteLine("Sent a desktop notification to the user with message: {0}", message);
    }
}
