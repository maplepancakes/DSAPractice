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
        new object[] { new[] { 1, 3, 2, 6, -1, 4, 1, 8, 2 }, 5, new List<double> { 2.2, 2.8, 2.4, 3.6, 2.8 } }
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

    public static IEnumerable<object[]> TestCasesFindMaximumInSubArrayOfKElements =>
        new List<object[]>
        {
        new object[] { new[] { 4, 2, 12, 3, 8, 7 }, 3, new List<int> { 12, 12, 12, 8 } },
        new object[] { new[] { 4, 2, 12 }, 3, new List<int> { 12 } },
        new object[] { new[] { 4, 2, 12, 6, 5, 4 }, 2, new List<int> { 4, 12, 12, 6, 5 } }
        };
    
    public static IEnumerable<object[]> TestCasesMaximumTemperatureInLastKHours =>
        new List<object[]>
        {
        new object[] { new[] { 30, 35, 40, 28, 33, 37, 42 }, 3, new List<int> { 40, 40, 40, 37, 42 } },
        new object[] { new[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3, new List<int> { 3, 3, 5, 5, 6, 7 } },
        new object[] { new[] { 5, 5, 5, 5 }, 2, new List<int> { 5, 5, 5 } },
        new object[] { new[] { 10 }, 1, new List<int> { 10 } },
        new object[] { new[] { 2, 4, 6, 8, 10 }, 2, new List<int> { 4, 6, 8, 10 } }
        };

    [Theory]
    [InlineData(new[] { 2, 1, 5, 1, 3, 2 }, 3, 9)]
    [InlineData(new[] { 2, 1, 5 }, 3, 8)]
    [InlineData(new[] { 9, 1, 5, 1, 3, 2 }, 3, 15)]
    [InlineData(new[] { 2, 1, 5, 1, 3, 10 }, 3, 14)]
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
    [InlineData(new int[] { 1, 3, 8, 15, 20 }, 10, 3, false)]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 5, 5, false)]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 3, 2, true)]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6 }, 5, 5, false)]
    [InlineData(new int[] { 1, 10, 11, 12, 13, 14, 30, 31, 32, 33, 34 }, 5, 3, true)]
    [InlineData(new int[] { 23, 25, 99, 106, 107, 133 }, 20, 3, false)]
    [InlineData(new int[] { 23, 25, 99, 106, 107, 112, 114, 115, 133 }, 20, 3, true)]
    public void Test_DetectDDoSAttack(int[] timestamps, int t, int n, bool expected)
    {
        bool result = _slidingWindow.DetectDDoSAttack(timestamps, t, n);
        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(TestCasesFindMaximumInSubArrayOfKElements))]
    public void Test_MaximumInSubArrayOfKElements(int[] nums, int k, List<int> expected)
    {
        List<int> result = _slidingWindow.FindMaximumInSubArrayOfKElements(nums, k);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new[] { 10, 20, 30, 40, 50, 60, 70, 80 }, 50)]
    [InlineData(new[] { 5, 5, 5, 5, 5, 5, 5, 5, 5 }, 5)]
    [InlineData(new[] { 1, 2, 3, 100, 100, 100, 100, 1, 1 }, 58)]
    [InlineData(new[] { 2, 4, 6, 8, 10, 12, 14 }, 8)]
    public void Test_MaximumAveragePlayerScoreOverA7DayStreak(int[] scores, int expected)
    {
        int result = _slidingWindow.MaximumAveragePlayerScoreOverA7DayStreak(scores);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new[] { 300, 200, 400, 500, 100, 300, 600 }, 5, 1900)]
    [InlineData(new[] { 10, 20, 30, 40, 50 }, 3, 120)]
    [InlineData(new[] { 5, 5, 5, 5, 5 }, 2, 10)]
    [InlineData(new[] { 100, 200 }, 2, 300)]
    [InlineData(new[] { 1, 2, 3, 4, 5, 6 }, 4, 18)]
    public void Test_ECommerceSalesStreak(int[] revenue, int k, int expected)
    {
        int result = _slidingWindow.ECommerceSalesStreak(revenue, k);
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(new[] { 1, 2, 3, 2, 4, 5 }, 4)]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 5)]
    [InlineData(new[] { 1, 1, 1, 1 }, 1)]
    [InlineData(new[] { 5, 6, 7, 5, 6, 7 }, 3)]
    [InlineData(new int[0], 0)]
    [InlineData(new[] { 1, 2, 3, 2, 4, 2 }, 3)]
    public void Test_LongestUniqueBrowsingSession(int[] pages, int expected)
    {
        int result = _slidingWindow.LongestUniqueBrowsingSession(pages);
        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(TestCasesMaximumTemperatureInLastKHours))]
    public void Test_MaximumTemperatureInLastKHours(int[] temps, int k, List<int> expected)
    {
        List<int> result = _slidingWindow.MaximumTemperatureInLastKHours(temps, k);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new[] { 2, 1, 5, 2, 3, 2 }, 7, 2)]
    [InlineData(new[] { 3, 4, 1, 1, 6 }, 8, 3)]
    public void Test_MinConsecutiveDaysToHitDataCapUsage(int[] usage, int cap, int expected)
    {
        int result = _slidingWindow.MinConsecutiveDaysToHitDataCapUsage(usage, cap);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new[] { 1, 2, 1, 1, 1, 3, 2 }, 5, 4)]
    [InlineData(new[] { 4, 2, 1 }, 3, 2)]
    [InlineData(new[] { 1, 1, 1, 1 }, 5, 4)]
    public void Test_MaxConsecutiveSequenceOfCustomerWaitTime(int[] waitTime, int serviceLimit, int expected)
    {
        int result = _slidingWindow.MaxConsecutiveSequenceOfCustomerWaitTime(waitTime, serviceLimit);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new[] { 10, 20, 30, 25, 35, 50 }, 2, 66)]
    public void Test_LargestPercentageIncrease(int[] nums, int k, int expected)
    {
        double result = _slidingWindow.LargestPercentageIncrease(nums, k);
        Assert.Equal(expected, result);
    }
}