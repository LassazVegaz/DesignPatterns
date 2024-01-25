namespace FactoryPattern.Core;

/// <summary>
/// Send a message to a user
/// </summary>
public interface ISender
{
    void Send(string message);
}
