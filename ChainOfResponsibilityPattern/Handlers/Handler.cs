using ChainOfResponsibilityPattern.Core;
using ChainOfResponsibilityPattern.Models;

namespace ChainOfResponsibilityPattern.Handlers;

internal abstract class Handler() : IHandler
{
    protected IHandler? next;


    public Handler(IHandler nextHandler) : this()
    {
        next = nextHandler;
    }


    public IHandler SetNext(IHandler handler) => next = handler;

    public abstract Response Handle(Request request);
}
