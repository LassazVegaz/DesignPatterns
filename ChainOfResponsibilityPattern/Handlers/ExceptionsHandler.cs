using ChainOfResponsibilityPattern.Core;
using ChainOfResponsibilityPattern.Models;

namespace ChainOfResponsibilityPattern.Handlers;

internal class ExceptionsHandler : Handler
{
    public ExceptionsHandler(IHandler next) : base(next) { }

    public ExceptionsHandler() { }


    public override Response Handle(Request request)
    {
        try
        {
            return next?.Handle(request) ?? new();
        }
        catch (Exception e)
        {
            return new() { Data = e };
        }
    }
}
