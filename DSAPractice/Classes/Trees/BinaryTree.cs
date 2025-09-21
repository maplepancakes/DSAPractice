namespace collections_and_data_iteration_fundamentals.Trees;

public class BinaryTree
{
    // DFS
    public void InorderTraversal(Node node)
    {
        if (node == null) return;
        
        InorderTraversal(node.Left);
        Console.WriteLine(node.Value);
        InorderTraversal(node.Right);
    }

    // DFS
    public void PreorderTraversal(Node node)
    {
        if (node == null) return;
        
        Console.WriteLine(node.Value);
        PreorderTraversal(node.Left);
        PreorderTraversal(node.Right);
    }

    // DFS
    public void PostorderTraversal(Node node)
    {
        if (node == null) return;

        PostorderTraversal(node.Left);
        PostorderTraversal(node.Right);
        Console.WriteLine(node.Value);
    }

    // BFS
    public void LevelOrderTraversal(Node node)
    {
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(node);

        while (queue.Count > 0)
        {
            Node currentNode = queue.Dequeue();
            Console.WriteLine(currentNode.Value);
            
            if (currentNode.Left != null) queue.Enqueue(currentNode.Left);
            if (currentNode.Right != null) queue.Enqueue(currentNode.Right);
        }
    }

    public int DepthOfTreeUsingBFS(Node node)
    {
        // Handle edge case where there is no tree
        if (node == null) return 0;
        
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(node);

        int depth = 0;
        while (queue.Count > 0)
        {
            int numberOfNodesAtCurrentLevel = queue.Count;
            for (int i = 0; i < numberOfNodesAtCurrentLevel; i++)
            {
                Node currentNode = queue.Dequeue();
                
                if (currentNode.Left != null) queue.Enqueue(currentNode.Left);
                if (currentNode.Right != null) queue.Enqueue(currentNode.Right);
            }

            depth++;
        }

        return depth;
    }

    public void EarliestInsertionOfBinaryTree(Node node, Node nodeToInsert)
    {
        if (node == null)
        {
            Console.WriteLine("No tree, hence nodeToInsert is the root");
            return;
        }
        
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(node);

        while (queue.Count > 0)
        {
            Node currentNode = queue.Dequeue();

            if (currentNode.Left == null)
            {
                currentNode.Left = nodeToInsert;
                break;
            }
            if (currentNode.Right == null)
            {
                currentNode.Right = nodeToInsert;
                break;
            }
            if (currentNode.Left != null) queue.Enqueue(currentNode.Left);
            if (currentNode.Right != null) queue.Enqueue(currentNode.Right);
        }
        
        LevelOrderTraversal(node);
    }
    
    public Node NodeDeletionOfBinaryTree(Node node, int valueToDelete)
    {
        // Handles edge case where there is no tree
        if (node == null)
        {
            Console.WriteLine("No tree exists.");
            return null;
        }
        // Handles edge case where only the root node exists in the tree
        if (node.Left == null && node.Right == null)
        {
            Console.WriteLine("Only root node exists. Deleted root node.");
            return null;
        }
        
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(node);

        Node parentNode = null;
        Node nodeToReplace = null;
        Node currentNode = null;
        
        // 1st pass: To find the node to delete
        while (queue.Count > 0)
        {
            currentNode = queue.Dequeue();
            
            if (currentNode.Left != null) queue.Enqueue(currentNode.Left);
            if (currentNode.Right != null) queue.Enqueue(currentNode.Right);

            if (currentNode.Value == valueToDelete) nodeToReplace = currentNode;
        }

        // Handles edge case where no node to delete is found
        if (nodeToReplace == null)
        {
            Console.WriteLine("No node with value to delete found.");
            return node;
        }
        
        // 2nd pass: To find the value of the rightest most node to replace the node to delete
        queue.Enqueue(node);
        currentNode = null;
        while (queue.Count > 0)
        {
            int numberOfNodesAtCurrentDepth = queue.Count;
            for (int i = 0; i < numberOfNodesAtCurrentDepth; i++)
            {
                currentNode = queue.Dequeue();
                
                if (currentNode.Left != null) queue.Enqueue(currentNode.Left);
                if (currentNode.Right != null) queue.Enqueue(currentNode.Right);

                // Condition for determining the rightest most node at the lowest depth
                if (queue.Count == 0)
                {
                    nodeToReplace.Value = currentNode.Value;

                    // Condition to ensure that the rightest most node is deleted
                    if (parentNode.Right != null) parentNode.Right = null;
                    else if (parentNode.Left != null) parentNode.Left = null;
                }
                
                // Condition for assigning parent node of final leaf node
                if (i + 1 == numberOfNodesAtCurrentDepth)
                {
                    parentNode = currentNode;
                }
            }
        }

        return node;
    }

    public Node InsertionOfBinarySearchTreeIteratively(Node node, int value)
    {
        // Handles edge case where no tree exists
        if (node == null)
        {
            Console.WriteLine("No tree exists.");
            return new Node(value);
        }
        
        Node parentNode = null;
        Node currentNode = node;
        
        // Find parent node to create a new child node with input value
        while (currentNode != null)
        {
            if (value == currentNode.Value)
            {
                Console.WriteLine("Binary search trees cannot have duplicate values.");
                return node;
            }

            parentNode = currentNode;
            if (value < currentNode.Value)
            {
                currentNode = currentNode.Left;
                continue;
            }
            if (value > currentNode.Value)
            {
                currentNode = currentNode.Right;
            }
        }

        // After the parent node has been found, use value comparison again to determine whether new node should be the left or right child of the parent node
        if (value < parentNode.Value)
        {
            parentNode.Left = new Node(value);
        }
        if (value > parentNode.Value)
        {
            parentNode.Right = new Node(value);
        }
        
        return node;
    }

    public Node InsertionOfBinarySearchTreeRecursively(Node node, int value)
    {
        // Handles edge case where no tree exists. Ensures that recursion will not even begin and a new root node with the input value is created
        if (node == null)
        {
            Console.WriteLine("No tree exists.");
            return new Node(value);
        }
        
        // Handles edge case where a duplicate value is passed in. Ensures that recursive stack unwinds before any insertion occurs
        if (value == node.Value)
        {
            Console.WriteLine("Duplicate value in binary search trees are not allowed.");
            return node;
        }
        
        if (value < node.Value)
        {
            // Insert left child node with value to parent node if there is no left child AND the value is less than the value of the current visited node
            if (node.Left == null)
            {
                node.Left = new Node(value);
                return node;
            }
            // If there is a left child AND the value is less than the value of the current visited node, continue traversing down the left subtree
            InsertionOfBinarySearchTreeRecursively(node.Left, value);
        }
        if (value > node.Value)
        {
            // Insert right child node with value to parent node if there is no right child AND the value is more than the value of the current visited node
            if (node.Right == null)
            {
                node.Right = new Node(value);
                return node;
            }
            // If there is a right child AND the value is more than the value of the current visited node, continue traversing down the right subtree
            InsertionOfBinarySearchTreeRecursively(node.Right, value);
        }

        return node;
    }
}