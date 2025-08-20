namespace collections_and_data_iteration_fundamentals;

public class SinglyListNode<T>
{
    public T Val { get; set; }
    public SinglyListNode<T> Next { get; set; }

    public SinglyListNode(T val, SinglyListNode<T> next)
    {
        this.Val = val;
        this.Next = next;
    }
}