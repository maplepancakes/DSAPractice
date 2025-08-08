using collections_and_data_iteration_fundamentals;

namespace DSAPractice.Test;

public class TestBinarySearch
{
    private readonly BinarySearch _binarySearch = new BinarySearch();
    
    [Theory]
    [InlineData(new[] { 101, 104, 107, 110, 115 }, 107, 2)]
    [InlineData(new[] { 101, 104, 107, 110, 115 }, 108, 3)]
    [InlineData(new[] { 101, 104, 107, 110, 115 }, 100, 0)]
    [InlineData(new[] { 101, 104, 107, 110, 115 }, 116, -1)]
    [InlineData(new int[] { }, 107, -1)]
    public void Test_GetPageStartIndex(int[] sortedItemIds, int targetId, int expected)
    {
        int result = _binarySearch.GetPageStartIndex(sortedItemIds, targetId);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new[] {1.0, 2.0, 3.0, 10.0, 10.0}, 3.0, 2)]
    [InlineData(new[] {1.0, 2.0, 3.0, 10.0, 10.0}, 4.0, 3)]
    [InlineData(new[] {1.0, 2.0, 3.0, 10.0, 10.0}, 2.0, 1)]
    [InlineData(new[] {1.0, 2.0, 3.0, 10.0, 10.0}, 12.0, -1)]
    [InlineData(new[] {1.0, 2.0, 3.0, 10.0, 10.0}, 0.5, 0)]
    [InlineData(new double[] {}, 3.0, -1)]
    public void Test_FindFirstDayWithHighAverage(double[] readings, double threshold, double expected)
    {
        int result = _binarySearch.FindFirstDayWithHighAverage(readings, threshold);
        Assert.Equal(expected, result);
    }
}