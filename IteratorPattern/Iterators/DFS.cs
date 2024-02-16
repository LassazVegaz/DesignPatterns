using IteratorPattern.Core;
using IteratorPattern.DS;

namespace IteratorPattern.Iterators;

internal class DFS : IIterator
{
    private BinaryTreeNode? current;
    private readonly Stack<BinaryTreeNode> stack = [];


    public DFS(BinaryTree tree)
    {
        current = tree.root;
        if (current != null) stack.Push(current);
    }

    public int GetCurrent() => current!.data;

    public bool HasNext() => stack.Count != 0;

    public int Next()
    {
        var node = stack.Pop();

        if (node.right != null) stack.Push(node.right);
        if (node.left != null) stack.Push(node.left);

        current = node;
        return node.data;
    }
}
