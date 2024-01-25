using FactoryPattern.Core;

namespace FactoryPattern.Factories;

abstract public class SendersFactory
{
    public abstract ISender CreateSender();
}
