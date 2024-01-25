using FactoryPattern.Core;
using FactoryPattern.Senders;

namespace FactoryPattern.Factories;

public class NotificationSendersFactory : SendersFactory
{
    private bool IsUserActiveOnDesktop => Random.Shared.Next(0, 100) > 50;

    public override ISender CreateSender() =>
        IsUserActiveOnDesktop ? new DesktopNotificationSender() : new MobileNotificationSender();
}
