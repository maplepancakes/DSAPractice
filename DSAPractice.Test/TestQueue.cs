using collections_and_data_iteration_fundamentals;

namespace DSAPractice.Test;

public class TestQueue
{
    private readonly Queue _queue = new Queue();
    
    public static IEnumerable<object[]> TestSupermarketCheckout =>
        new List<object[]>
        { 
        new object[] { new Queue<string>(["Bob", "Andy", "Macky", "Jessica", "Bench"]), "Bob" },
        new object[] { new Queue<string>(["Bob", "Andy", "Macky", "Jessica", "Bench"]), "Jessica" },
        new object[] { new Queue<string>(["Bob", "Andy", "Macky", "Jessica", "Bench"]), "Bench" },
        };
    
    [Fact]
    public void Test_SupermarketCheckout()
    {
        _queue.SupermarketCheckout(["Bob", "Andy", "Jessica", "Mandy", "Hannibal"]);
    }

    [Theory]
    [MemberData(nameof(TestSupermarketCheckout))]
    public void Test_RemovePassenger(Queue<string> passengers, string passengerToRemove)
    {
        Queue<string> result = _queue.RemovePassenger(passengers, passengerToRemove);
        Assert.False(result.Contains(passengerToRemove));
    }
}