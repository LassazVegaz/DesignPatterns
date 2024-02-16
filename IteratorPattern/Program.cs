using IteratorPattern.Core;
using IteratorPattern.DS;
using IteratorPattern.Iterators;

static void Traverse(IIterator algo)
{
    Console.WriteLine("Traversing the tree");
    var str = "";

    while (algo.HasNext())
    {
        str += $"{algo.Next()} -> ";
    }

    str = str[..^4];
    Console.WriteLine(str);
}

static BinaryTree CreateTree()
{
    var tree = new BinaryTree { root = new() { data = 1, } };

    tree.root.left = new() { data = 2, };
    tree.root.right = new() { data = 3, };
    tree.root.left.left = new() { data = 4, };
    tree.root.left.right = new() { data = 5, };
    tree.root.right.left = new() { data = 6, };
    tree.root.right.right = new() { data = 7, };
    tree.root.left.left.left = new() { data = 8, };
    tree.root.left.left.right = new() { data = 9, };

    return tree;
}

Console.WriteLine("How do you want to traverse the tree?");
Console.WriteLine("1. Depth First Traversal");
Console.WriteLine("2. Breadth First Traversal");
Console.Write("Select an option: ");
var option = Console.ReadLine();
Console.WriteLine();

var tree = CreateTree();
IIterator? algo = option switch
{
    "1" => new DFS(tree),
    "2" => new BFS(tree),
    _ => null,
};
if (algo == null)
{
    Console.WriteLine("Invalid option selected");
    return;
}

Traverse(algo);
