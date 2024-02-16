namespace IteratorPattern.Core;

internal interface IIterator
{
    public bool HasNext();
    public int Next();
    public int GetCurrent();
}
