namespace collections_and_data_iteration_fundamentals;

public class DoublyListNode<T>
{
    public T Val { get; set; }
    public DoublyListNode<T> Next { get; set; }
    public DoublyListNode<T> Prev { get; set; }

    public DoublyListNode(T val, DoublyListNode<T> next, DoublyListNode<T> prev)
    {
        this.Val = val;
        this.Next = next;
        this.Prev = prev;
    }
}