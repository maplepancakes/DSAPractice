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
    
    public static IEnumerable<object[]> TestAddNewTask =>
        new List<object[]>
        { 
            new object[] { null, "do homework" },
            new object[] { new SinglyListNode<string>("do nothing", 
                new SinglyListNode<string>("procrastinate", 
                    new SinglyListNode<string>("try your best", null))), "do homework" }
        };
    
    public static IEnumerable<object[]> TestInsertStopAfterAGivenStop =>
        new List<object[]>
        { 
            new object[] { new SinglyListNode<string>("Stop A", 
                new SinglyListNode<string>("Stop B", 
                    new SinglyListNode<string>("Stop C", null))), "Stop B", "Stop B1" },
            new object[] { new SinglyListNode<string>("Stop A", 
                new SinglyListNode<string>("Stop B", 
                    new SinglyListNode<string>("Stop C", null))), "Stop C", "Stop C1" },
            new object[] { new SinglyListNode<string>("Stop A", 
                new SinglyListNode<string>("Stop B", 
                    new SinglyListNode<string>("Stop C", null))), "Stop F", "Stop C1" },
            new object[] { null, "Stop A", "Stop A1" },
        };
    
    public static IEnumerable<object[]> TestCancelOrder =>
        new List<object[]>
        { 
            new object[] { new SinglyListNode<string>("Order A", 
                new SinglyListNode<string>("Order B", 
                    new SinglyListNode<string>("Order C", null))), "Order B" },
            new object[] { new SinglyListNode<string>("Order A", 
                new SinglyListNode<string>("Order B", 
                    new SinglyListNode<string>("Order C", null))), "Order C" },
            new object[] { new SinglyListNode<string>("Order A", 
                new SinglyListNode<string>("Order B", 
                    new SinglyListNode<string>("Order C", null))), "Order F" },
            new object[] { new SinglyListNode<string>("Order A", 
                new SinglyListNode<string>("Order B", 
                    new SinglyListNode<string>("Order C", null))), "Order A" },
            new object[] { new SinglyListNode<string>("Order A", null), "Order A" },
            new object[] { null, "Order A" },
        };
    
    public static IEnumerable<object[]> TestReverseOrder =>
        new List<object[]>
        { 
            new object[] { new SinglyListNode<string>("A", 
                new SinglyListNode<string>("B", 
                    new SinglyListNode<string>("C", 
                        new SinglyListNode<string>("D", null)))) },
        };
    
    public static IEnumerable<object[]> TestFindMiddle =>
        new List<object[]>
        { 
            new object[] { new SinglyListNode<string>("A", 
                new SinglyListNode<string>("B", 
                    new SinglyListNode<string>("C", 
                        new SinglyListNode<string>("D", 
                            new SinglyListNode<string>("E", null))))) },
            new object[] { new SinglyListNode<string>("A", 
                new SinglyListNode<string>("B", 
                    new SinglyListNode<string>("C", 
                        new SinglyListNode<string>("D", 
                            new SinglyListNode<string>("E", 
                                new SinglyListNode<string>("F", null)))))) },
            new object[] { new SinglyListNode<string>("A", 
                new SinglyListNode<string>("B", 
                    new SinglyListNode<string>("C", null))) },
            new object[] { new SinglyListNode<string>("A", null) },
            new object[] { new SinglyListNode<string>("A", 
                new SinglyListNode<string>("B", null)) },
            new object[] { null },
        };
        
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

    [Theory]
    [MemberData(nameof(TestAddNewTask))]
    public void Test_AddNewTask(SinglyListNode<string> head, string task)
    {
        _linkedList.AddNewTask(head, task);
    }

    [Theory]
    [MemberData(nameof(TestInsertStopAfterAGivenStop))]
    public void Test_InsertStopAfterAGivenStop(SinglyListNode<string> head, string valueToInsertAt, string valueToInsert)
    {
        _linkedList.InsertStopAfterAGivenStop(head, valueToInsertAt, valueToInsert);
    }
    
    [Theory]
    [MemberData(nameof(TestCancelOrder))]
    public void Test_CancelOrder(SinglyListNode<string> head, string orderToCancel)
    {
        _linkedList.CancelOrder(head, orderToCancel);
    }
    
    [Theory]
    [MemberData(nameof(TestReverseOrder))]
    public void Test_ReverseOrder(SinglyListNode<string> head)
    {
        _linkedList.ReverseOrder(head);
    }

    [Theory]
    [MemberData(nameof(TestFindMiddle))]
    public void Test_FindMiddleUsingOnePassSolution(SinglyListNode<string> head)
    {
        _linkedList.FindMiddleUsingOnePassSolution(head);
    }
}