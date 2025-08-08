using collections_and_data_iteration_fundamentals;

namespace DSAPractice.Test;

public class TestSlidingWindow
{
    private readonly SlidingWindow _slidingWindow = new SlidingWindow();
    
    public static IEnumerable<object[]> TestCasesAverageOfSubArrays =>
        new List<object[]>
        { 
        new object[] { new[] { 1, 2, 3 }, 2, new List<double> { 1.5, 2.5 } },
        new object[] { new[] { 4, 5, 6 }, 3, new List<double> { 5.0 } },
        new object[] { new[] {1, 3, 2, 6, -1, 4, 1, 8, 2}, 5, new List<double> { 2.2, 2.8, 2.4, 3.6, 2.8 } }
        };
    
    public static IEnumerable<object[]> TestCasesLongestUniqueWindow =>
        new List<object[]>
        { 
        new object[] { new List<string> { "A", "B", "C", "A", "B", "D" }, 4 },
        new object[] { new List<string> { "aa", "bb", "cc", "aa", "dd" }, 4 },
        new object[] { new List<string> { "Blinding Lights", "Starboy", "Blinding Lights", "Save Your Tears" }, 3 },
        new object[] { new List<string> { "A", "B", "B", "B" }, 2 },
        new object[] { new List<string> { "A", "B", "C", "A", "A", "D", "E", "F", "E" }, 4 },
        new object[] { new List<string> { "A", "B", "C", "B", "B", "C", "D" }, 3 }
        };

    [Theory]
    [InlineData(new[] {2, 1, 5, 1, 3, 2}, 3, 9)]
    [InlineData(new[] {2, 1, 5}, 3, 8)]
    [InlineData(new[] {9, 1, 5, 1, 3, 2}, 3, 15)]
    [InlineData(new[] {2, 1, 5, 1, 3, 10}, 3, 14)]
    public void Test_MaximumSumOfSubArray(int[] arr, int k, int expected)
    {
        int result = _slidingWindow.MaximumSumOfSubArray(arr, k);
        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(TestCasesAverageOfSubArrays))]
    public void Test_AverageOfSubArrays(int[] arr, int k, List<double> expected)
    {
        List<double> result = _slidingWindow.AverageOfSubArrays(arr, k);
        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(TestCasesLongestUniqueWindow))]
    public void Test_LongestUniqueWindow(List<string> input, int expected)
    {
        int result = _slidingWindow.LongestUniqueWindow(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] {1, 3, 8, 15, 20}, 10, 3, false)]
    [InlineData(new int[] {1, 2, 3, 4, 5}, 5, 5, false)]
    [InlineData(new int[] {1, 2, 3, 4, 5}, 3, 2, true)]
    [InlineData(new int[] {1, 2, 3, 4, 5, 6}, 5, 5, false)]
    [InlineData(new int[] {1, 10, 11, 12, 13, 14, 30, 31, 32, 33, 34}, 5, 3, true)]
    [InlineData(new int[] {23, 25, 99, 106, 107, 133}, 20, 3, false)]
    [InlineData(new int[] {23, 25, 99, 106, 107, 112, 114, 115, 133}, 20, 3, true)]
    public void Test_DetectDDoSAttack(int[] timestamps, int t, int n, bool expected)
    {
        bool result = _slidingWindow.DetectDDoSAttack(timestamps, t, n);
        Assert.Equal(expected, result);
    }
}