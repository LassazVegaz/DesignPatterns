using ChainOfResponsibilityPattern.Models;

namespace ChainOfResponsibilityPattern.Core;

internal interface IHandler
{
    IHandler SetNext(IHandler handler);
    Response Handle(Request request);
}
