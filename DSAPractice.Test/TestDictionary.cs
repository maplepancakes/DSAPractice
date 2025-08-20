using collections_and_data_iteration_fundamentals;

namespace DSAPractice.Test;

public class TestDictionary
{
    private readonly Dictionary _dictionary = new Dictionary();
    
    public static IEnumerable<object[]> TestGroupAnagrams =>
        new List<object[]>
        { 
        new object[] { new[] { "tan", "ant", "eat", "ate" }, new List<List<string>> { new() { "tan", "ant" }, new() { "eat", "ate" } } }
        };
    
    [Theory]
    [MemberData(nameof(TestGroupAnagrams))]
    public void Test_GroupAnagramsSolutionOne(string[] anagrams, List<List<string>> expected)
    {
        List<List<string>> result = _dictionary.GroupAnagramsSolutionOne(anagrams);
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [MemberData(nameof(TestGroupAnagrams))]
    public void Test_GroupAnagramsSolutionTwo(string[] anagrams, List<List<string>> expected)
    {
        List<List<string>> result = _dictionary.GroupAnagramsSolutionTwo(anagrams);
        Assert.Equal(expected, result);
    }
}