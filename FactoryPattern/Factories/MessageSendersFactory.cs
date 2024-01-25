using FactoryPattern.Core;
using FactoryPattern.Senders;

namespace FactoryPattern.Factories;

public class MessageSendersFactory(string phoneNumber) : SendersFactory
{
    private readonly string _phoneNumber = phoneNumber;

    private bool HasEnoughCredits => Random.Shared.Next(0, 100) > 50;

    public override ISender CreateSender() =>
        HasEnoughCredits ? new SmsSender(_phoneNumber) : new WhatsAppSender(_phoneNumber);
}
