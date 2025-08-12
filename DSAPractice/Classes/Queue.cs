namespace collections_and_data_iteration_fundamentals;

public class Queue
{
    public void SupermarketCheckout(string[] customers)
    {
        Queue<string> queue = new Queue<string>();
        foreach (string customer in customers)
        {
            queue.Enqueue(customer);
        }

        foreach (string customer in queue)
        {
            Console.WriteLine($"Serving: {customer}");
        }
    }

    public Queue<string> RemovePassenger(Queue<string> passengers, string passengerToRemove)
    {
        Queue<string> queueWithRemovedPassenger = new Queue<string>();
        while (passengers.Count > 0)
        {
            string passenger = passengers.Dequeue();
            if (passenger.Equals(passengerToRemove)) continue;
            queueWithRemovedPassenger.Enqueue(passenger);
        }
        
        return queueWithRemovedPassenger;
    }
    
}