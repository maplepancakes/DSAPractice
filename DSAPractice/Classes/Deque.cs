namespace collections_and_data_iteration_fundamentals;

public class Deque
{
    public bool IsPalindrome(string input)
    {
        LinkedList<char> deque = new LinkedList<char>();
        foreach (char character in input)
        {
            deque.AddLast(character);
        }

        while (deque.Count > 1)
        {
            if (deque.First.Value != deque.Last.Value) return false;
            deque.RemoveFirst();
            deque.RemoveLast();
        }

        return true;
    }
}