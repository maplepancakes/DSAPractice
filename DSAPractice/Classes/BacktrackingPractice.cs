namespace collections_and_data_iteration_fundamentals;

public class BacktrackingPractice
{
    public void GenerateBinaryStrings(String currentString, int n)
    {
        if (n == 0)
        {
            Console.WriteLine($"GenerateBinaryStrings: {currentString}");
            return;
        }
        
        GenerateBinaryStrings(currentString + 0, n - 1);
        GenerateBinaryStrings(currentString + 1, n - 1);
    }
}