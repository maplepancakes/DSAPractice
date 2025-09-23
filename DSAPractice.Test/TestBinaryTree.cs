using collections_and_data_iteration_fundamentals.Trees;

namespace DSAPractice.Test;

public class TestBinaryTree
{
    private readonly BinaryTree _binaryTree = new BinaryTree();

    private Node createBinaryTree()
    {
        // Level 1
        Node rootNode = new Node(1);
        
        // Level 2
        rootNode.Left = new Node(2);
        rootNode.Right = new Node(3);
        
        // Level 3
        rootNode.Left.Left = new Node(4);
        rootNode.Left.Right = new Node(5);
        rootNode.Right.Right = new Node(6);

        return rootNode;
    }
    
    private Node createBinarySearchTree()
    {
        // Level 1
        Node rootNode = new Node(100);
        
        // Level 2
        rootNode.Left = new Node(20);
        rootNode.Right = new Node(500);
        
        // Level 3
        rootNode.Left.Left = new Node(10);
        rootNode.Left.Right = new Node(30);
        rootNode.Right.Left = new Node(250);

        return rootNode;
    }
    
    [Fact]
    public void Test_InorderTraversal()
    {
        // Expected output: 4 -> 2 -> 5 -> 1 -> 3 -> 6
        _binaryTree.InorderTraversal(createBinaryTree());
    }

    [Fact]
    public void Test_PreorderTraversal()
    {
        // Expected output: 1 -> 2 -> 4 -> 5 -> 3 -> 6
        _binaryTree.PreorderTraversal(createBinaryTree());
    }

    [Fact]
    public void Test_PostorderTraversal()
    {
        // Expected output: 4 -> 5 -> 2 -> 6 -> 3 -> 1
        _binaryTree.PostorderTraversal(createBinaryTree());
    }

    [Fact]
    public void Test_LevelOrderTraversal()
    {
        // Expected output: 1 -> 2 -> 3 -> 4 -> 5 -> 6
        _binaryTree.LevelOrderTraversal(createBinaryTree());
    }

    [Fact]
    public void Test_DepthOfTreeUsingBFS()
    {
        int depth = _binaryTree.DepthOfTreeUsingBFS(createBinaryTree());
        Assert.Equal(3, depth);
    }

    [Fact]
    public void Test_EarliestInsertionOfTreeUsingBFS()
    {
        // Expected output: 1 -> 2 -> 3 -> 4 -> 5 -> 999 -> 6
        _binaryTree.EarliestInsertionOfBinaryTree(createBinaryTree(), new Node(999));
    }

    [Fact]
    public void Test_NodeDeletionUsingBFS()
    {
        Node node = _binaryTree.NodeDeletionOfBinaryTree(createBinaryTree(), 11);
        
        // Expected output: 1 -> 6 -> 3 -> 4 -> 5 (using level order traversal)
        _binaryTree.LevelOrderTraversal(node);
    }

    [Fact]
    public void Test_InsertionOfBinarySearchTreeIteratively()
    {
        Node node = _binaryTree.InsertionOfBinarySearchTreeIteratively(createBinarySearchTree(), 40);
        
        // Expected output: 10 -> 20 -> 30 -> 40 -> 100 -> 250 -> 500
        _binaryTree.InorderTraversal(node);
    }

    [Fact]
    public void Test_InsertionOfBinarySearchTreeRecursively()
    {
        Node node = _binaryTree.InsertionOfBinarySearchTreeRecursively(createBinarySearchTree(), 40);
        
        // Expected output: 10 -> 20 -> 30 -> 40 -> 100 -> 250 -> 500
        _binaryTree.InorderTraversal(node);
    }

    [Fact]
    public void Test_DeleteNodeFromBinarySearchTreeIteratively()
    {
        // Case 1 (no child node), expected output: 20 -> 30 -> 100 -> 250 -> 500
        Node node = _binaryTree.DeleteNodeFromBinarySearchTreeIteratively(createBinarySearchTree(), 10);
        Console.WriteLine("CASE 1: NO CHILD NODE");
        _binaryTree.InorderTraversal(node);
        Console.WriteLine("=====================");
        
        // Case 2 (one child node), expected output: 10 -> 20 -> 30 -> 100 -> 250
        Console.WriteLine("CASE 2: ONE CHILD NODE");
        node = _binaryTree.DeleteNodeFromBinarySearchTreeIteratively(createBinarySearchTree(), 500);
        _binaryTree.InorderTraversal(node);
        Console.WriteLine("=====================");
        
        // Case 3 (two child nodes), expected output: 10 -> 30 -> 100 -> 250 -> 500
        Console.WriteLine("CASE 3: TWO CHILD NODES");
        node = _binaryTree.DeleteNodeFromBinarySearchTreeIteratively(createBinarySearchTree(), 20);
        _binaryTree.InorderTraversal(node);
    }

    [Fact]
    public void Test_DeleteNodeFromBinarySearchTreeRecursively()
    {
        // Case 1 (no child node), expected output: 20 -> 30 -> 100 -> 250 -> 500
        Node node = _binaryTree.DeleteNodeFromBinarySearchTreeRecursively(createBinarySearchTree(), 10);
        Console.WriteLine("CASE 1: NO CHILD NODE");
        _binaryTree.InorderTraversal(node);
        Console.WriteLine("=====================");
        
        // Case 2 (one child node), expected output: 10 -> 20 -> 30 -> 100 -> 250
        Console.WriteLine("CASE 2: ONE CHILD NODE");
        node = _binaryTree.DeleteNodeFromBinarySearchTreeRecursively(createBinarySearchTree(), 500);
        _binaryTree.InorderTraversal(node);
        Console.WriteLine("=====================");
        
        // Case 3 (two child nodes), expected output: 10 -> 30 -> 100 -> 250 -> 500
        Console.WriteLine("CASE 3: TWO CHILD NODES");
        node = _binaryTree.DeleteNodeFromBinarySearchTreeRecursively(createBinarySearchTree(), 20);
        _binaryTree.InorderTraversal(node);
    }
}