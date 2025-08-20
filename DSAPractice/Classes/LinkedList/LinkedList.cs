using collections_and_data_iteration_fundamentals;

namespace DSAPractice.Classes.LinkedList;

public class LinkedList
{
    public string PrintUserBrowsingHistory(SinglyListNode<string> head)
    {
        List<string> browsingHistories = new List<string>();
        
        SinglyListNode<string> current = head;
        while (current != null)
        {
            browsingHistories.Add(current.Val);
            current = current.Next;
        }

        return String.Join(" -> ", browsingHistories);
    }

    public string OverwriteAtPosition(SinglyListNode<string> head, string value, int position)
    {
        List<string> result = new List<string>();
        
        int currentPosition = 1;
        SinglyListNode<string> current = head;
        while (current != null)
        {
            if (currentPosition == position)
            {
                current.Val = value;
            }
            result.Add(current.Val);

            current = current.Next;
            currentPosition++;
        }

        return String.Join(" -> ", result);
    }

    public int CountNumberOfNodes(SinglyListNode<int> head)
    {
        int numberOfNodes = 0;
        
        SinglyListNode<int> current = head;
        while (current != null)
        {
            numberOfNodes++;
            current = current.Next;
        }

        return numberOfNodes;
    }

    public bool DoesValueExist(SinglyListNode<int> head, int x)
    {
        SinglyListNode<int> current = head;
        while (current != null)
        {
            if (current.Val == x) return true;
            current = current.Next;
        }

        return false;
    }

    public int FindMaximumValue(SinglyListNode<int> head)
    {
        int maxValue = head.Val;
        
        SinglyListNode<int> current = head;
        while (current != null)
        {
            if (current.Val > maxValue) maxValue = current.Val;
            current = current.Next;
        }

        return maxValue;
    }

    public void AddNewTask(SinglyListNode<string> head, string task)
    {
        if (head == null)
        {
            head = new SinglyListNode<string>(task, null);
            Console.WriteLine(head.Val);
            return;
        }
        
        SinglyListNode<string> current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = new SinglyListNode<string>(task, null);

        List<string> result = new List<string>();
        current = head;
        while (current != null)
        {
            result.Add(current.Val);
            current = current.Next;
        }
        
        Console.WriteLine(String.Join(" -> ", result));
    }

    public void InsertStopAfterAGivenStop(SinglyListNode<string> head, string valueToInsertAt, string valueToInsert)
    {
        if (head == null)
        {
            return; // no head means nothing to insert after, hence just do nothing
        }
        
        SinglyListNode<string> current = head;
        while (current != null)
        {
            if (current.Val == valueToInsertAt)
            {
                SinglyListNode<string> nextNodeBeforeInsertion = current.Next;
                current.Next = new SinglyListNode<string>(valueToInsert, nextNodeBeforeInsertion);
                break; // stop insertion after first occurrence found
            }
            
            current = current.Next;
        }
        
        // additional code to print for understanding
        List<string> result = new List<string>();
        current = head;
        while (current != null)
        {
            result.Add(current.Val);
            current = current.Next;
        }
        Console.WriteLine(String.Join(" -> ", result));
    }

    public void CancelOrder(SinglyListNode<string> head, string orderToCancel)
    {
        if (head == null)
        {
            Console.WriteLine("no list of orders");
            return;
        }
        if (head.Val == orderToCancel)
        {
            head = head.Next;
            Console.WriteLine("removed head");
            return;
        }

        SinglyListNode<string> current = head;
        while (current != null)
        {
            if (current.Next != null && current.Next.Val == orderToCancel)
            {
                SinglyListNode<string> newNeighboringNode = current.Next.Next;
                current.Next = newNeighboringNode;
                break;
            }
            current = current.Next;
        }

        List<string> result = new List<string>();
        current = head;
        while (current != null)
        {
            result.Add(current.Val);
            current = current.Next;
        }
        Console.WriteLine(String.Join(" -> ", result));
    }

    public void ReverseOrder(SinglyListNode<string> head)
    {
        SinglyListNode<string> current = head;
        SinglyListNode<string> next;
        SinglyListNode<string> prev = null;
        while (current != null)
        {
            next = current.Next;
            current.Next = prev;
            prev = current;
            current = next;
        }

        List<string> result = new List<string>();
        current = prev;
        while (current != null)
        {
            result.Add(current.Val);
            current = current.Next;
        }
        Console.WriteLine(String.Join(" -> ", result));
    }
}