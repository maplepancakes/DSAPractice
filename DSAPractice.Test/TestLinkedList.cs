using collections_and_data_iteration_fundamentals;
using DSAPractice.Classes.LinkedList;

namespace DSAPractice.Test;

public class TestLinkedList
{
    private readonly LinkedList _linkedList = new LinkedList();

    private SinglyListNode<string> _initializeHeadNode()
    {
        return new SinglyListNode<string>("Page 1",
        new SinglyListNode<string>("Page 2",
        new SinglyListNode<string>("Page 3", null)));
    }
    
    [Fact]
    public void Test_PrintUserBrowsingHistory()
    {
        SinglyListNode<string> head = _initializeHeadNode();

        string result = _linkedList.PrintUserBrowsingHistory(head);
        Assert.Equal("Page 1 -> Page 2 -> Page 3", result);
    }

    [Fact]
    public void Test_InsertAtPosition()
    {
        SinglyListNode<string> head = _initializeHeadNode();
        string result = _linkedList.OverwriteAtPosition(head, "AWOOGA", 2);
        Assert.Equal("Page 1 -> AWOOGA -> Page 3", result);
        
        head = _initializeHeadNode();
        result = _linkedList.OverwriteAtPosition(head, "AWOOGA", 1);
        Assert.Equal("AWOOGA -> Page 2 -> Page 3", result);
        
        head = _initializeHeadNode();
        result = _linkedList.OverwriteAtPosition(head, "AWOOGA", 3);
        Assert.Equal("Page 1 -> Page 2 -> AWOOGA", result);
        
        head = _initializeHeadNode();
        result = _linkedList.OverwriteAtPosition(head, "AWOOGA", 999);
        Assert.Equal("Page 1 -> Page 2 -> Page 3", result);
    }
}