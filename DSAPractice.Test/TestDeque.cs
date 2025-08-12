using collections_and_data_iteration_fundamentals;

namespace DSAPractice.Test;

public class TestDeque
{
    private readonly Deque _deque = new Deque();

    [Theory]
    [InlineData("madam", true)]
    [InlineData("thisisnotapalindrome", false)]
    [InlineData("cattac", true)]
    public void Test_IsPalindrome(string input, bool expected)
    {
        bool result = _deque.IsPalindrome(input);
        Assert.Equal(expected, result);
    }
}