using CommandPattern.Core;
using CommandPattern.Models;

namespace CommandPattern.Commands;

internal abstract class Command : ICommand
{

    protected List<ICommand>? history;
    public List<ICommand> CommandsHistory { set => history = value; }

    protected AppState? appState;
    public AppState AppState { set => appState = value; }


    abstract public void Execute();
}