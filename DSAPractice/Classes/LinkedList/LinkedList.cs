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
}