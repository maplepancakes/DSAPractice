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

    public void FindMiddleUsingTwoPassSolution(SinglyListNode<string> head)
    {
        int lengthOfLinkedList = 0;

        SinglyListNode<string> current = head;
        while (current != null)
        {
            lengthOfLinkedList++;
            current = current.Next;
        }

        int middleNode = (lengthOfLinkedList / 2) + 1;
        int currentCount = 1;
        current = head;
        while (currentCount != middleNode)
        {
            current = current.Next;
            currentCount++;
        }
        
        Console.WriteLine($"Middle value: {current.Val}");
    }

    public void FindMiddleUsingOnePassSolution(SinglyListNode<string> head)
    {
        if (head == null)
        {
            Console.WriteLine("no middle node is found because head is null");
            return;
        }
        if (head.Next == null)
        {
            Console.WriteLine("middle node is head");
            return;
        }

        SinglyListNode<string> slow = head;
        SinglyListNode<string> fast = head;
        while (fast != null && fast.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
        }
        
        Console.WriteLine($"middle node is {slow.Val}");
    }

    public void DetectCircularUsingHashSet(SinglyListNode<string> head)
    {
        if (head == null)
        {
            Console.WriteLine("no detection done as head is null");
            return;
        }

        HashSet<SinglyListNode<string>> visitedNodes = new HashSet<SinglyListNode<string>>();
        SinglyListNode<string> current = head;
        while (current != null)
        {
            if (visitedNodes.Contains(current))
            {
                Console.WriteLine($"Linked list contains cycle");
                return;
            }

            visitedNodes.Add(current);
            current = current.Next;
        }
    }

    public void DetectCircularUsingPointers(SinglyListNode<string> head)
    {
        if (head == null)
        {
            Console.WriteLine("No detection required as head is null");
            return;
        }

        SinglyListNode<string> tortoise = head;
        SinglyListNode<string> hare = head;
        while (hare != null && hare.Next != null)
        {
            tortoise = tortoise.Next;
            hare = hare.Next.Next;
            
            if (hare == tortoise)
            {
                Console.WriteLine("Cycle detected");
                return;
            }
        }
    }

    public SinglyListNode<int> MergeSortedLinkedLists(SinglyListNode<int> headA, SinglyListNode<int> headB)
    {
        SinglyListNode<int> newHead = new SinglyListNode<int>(-1, null);
        SinglyListNode<int> current = newHead;

        while (headA != null && headB != null)
        {
            if (headA.Val < headB.Val)
            {
                current.Next = headA;
                headA = headA.Next;
                current = current.Next;
                continue;
            }
            if (headA.Val > headB.Val)
            {
                current.Next = headB;
                headB = headB.Next;
                current = current.Next;
                continue;
            }
            if (headA.Val == headB.Val)
            {
                current.Next = headA;
                headA = headA.Next;
                current = current.Next;
                
                current.Next = headB;
                headB = headB.Next;
                current = current.Next;
            }
        }

        if (headA != null) current.Next = headA;
        if (headB != null) current.Next = headB;

        return newHead.Next;
    }

    public SinglyListNode<int> RemoveDuplicatesFromSortedLinkedList(SinglyListNode<int> head)
    {
        SinglyListNode<int> current = head;
        while (current != null && current.Next != null)
        {
            if (current.Val == current.Next.Val)
            {
                current.Next = current.Next.Next;
            }
            else
            {
                current = current.Next;
            }
        }

        return head;
    }

    public bool IntersectingNodesUsingHashSet(SinglyListNode<int> headA, SinglyListNode<int> headB)
    {
        HashSet<SinglyListNode<int>> visitedNodes = new HashSet<SinglyListNode<int>>();

        while (headA != null)
        {
            visitedNodes.Add(headA);
            headA = headA.Next;
        }

        while (headB != null)
        {
            if (visitedNodes.Contains(headB))
            {
                return true;
            }
            headB = headB.Next;
        }

        return false;
    }

    public bool IntersectingNodesUsingPointers(SinglyListNode<int> headA, SinglyListNode<int> headB)
    {
        SinglyListNode<int> pointerA = headA;
        SinglyListNode<int> pointerB = headB;
        while (pointerA != pointerB)
        {


            pointerA = pointerA == null ? headB : pointerA.Next;
            pointerB = pointerB == null ? headA : pointerB.Next;
        }

        return pointerA != null;
    }

    public void ForwardAndBackwardTraversal(LinkedList<string> linkedList)
    {
        if (linkedList == null || linkedList.Count == 0) return;
        
        LinkedListNode<string> current = linkedList.First;
        while (current != null)
        {
            Console.WriteLine(current.Value);
            current = current.Next;
        }

        current = linkedList.Last;
        while (current != null)
        {
            Console.WriteLine(current.Value);
            current = current.Previous;
        }
    }

    public LinkedListNode<string> ReverseBuiltInLinkedList(LinkedListNode<string> head)
    {
        if (head == null || head.Next == null) return head;
        
        LinkedList<string> reversedLinkedList = new LinkedList<string>();
        LinkedListNode<string> current = head;
        while (current != null)
        {
            reversedLinkedList.AddFirst(current.Value);
            current = current.Next;
        }

        return reversedLinkedList.First;
    }

    public bool IntersectingNodesUsingBuiltInLinkedList(LinkedListNode<string> headA, LinkedListNode<string> headB)
    {
        if (headA == null || headB == null) return false;

        LinkedListNode<string> pointerA = headA;
        LinkedListNode<string> pointerB = headB;
        while (pointerA != pointerB)
        {
            pointerA = pointerA == null ? headB : pointerA.Next;
            pointerB = pointerB == null ? headA : pointerB.Next;
        }

        return pointerA != null;
    }

    public DoublyListNode<string> ReverseDoublyLinkedList(DoublyListNode<string> head)
    {
        if (head == null || head.Next == null) return head;

        DoublyListNode<string> current = head;
        while (current != null)
        {
            DoublyListNode<string> nextNode = current.Next;
            current.Next = current.Prev;
            current.Prev = nextNode;

            if (current.Prev == null) head = current;
            current = current.Prev;
        }

        return head;
    }
}