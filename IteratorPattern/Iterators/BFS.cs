using IteratorPattern.Core;
using IteratorPattern.DS;

namespace IteratorPattern.Iterators;

internal class BFS : IIterator
{
    private BinaryTreeNode? current;
    private readonly Queue<BinaryTreeNode> queue = [];


    public BFS(BinaryTree tree)
    {
        current = tree.root;
        if (current != null) queue.Enqueue(current);
    }

    public int GetCurrent() => current!.data;

    public bool HasNext() => queue.Count != 0;

    public int Next()
    {
        var node = queue.Dequeue();

        if (node.left != null) queue.Enqueue(node.left);
        if (node.right != null) queue.Enqueue(node.right);

        current = node;
        return node.data;
    }
}
