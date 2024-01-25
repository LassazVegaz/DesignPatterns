using FactoryPattern.Factories;

const string userName = "James Bond";
const string userNumber = "+1234567890";

static SendersFactory GetSendersFactory(SendMethod method)
    => method switch
    {
        SendMethod.Message => new MessageSendersFactory(userNumber),
        SendMethod.Notification => new NotificationSendersFactory(),
        _ => throw new NotImplementedException(),
    };

Console.WriteLine("You are about to send a gift card to the user {0}", userName);
Console.WriteLine("How do you want to notify the user?");
Console.WriteLine("1. Message");
Console.WriteLine("2. Notification");
Console.Write("Please enter an option: ");
var inputStr = Console.ReadLine();

if (!Enum.TryParse(inputStr, true, out SendMethod method))
{
    Console.WriteLine("Invalid input");
    return;
}

var factory = GetSendersFactory(method);
var sender = factory.CreateSender();
sender.Send("A gift card was sent to you");

enum SendMethod
{
    Message = 1,
    Notification = 2,
};
