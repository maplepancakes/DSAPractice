namespace collections_and_data_iteration_fundamentals;

/*
 * Things to remember: -
 * - Any code placed before recursion will occur before recursion (e.g. PrintNumbersFromNToOne), and any code placed after recursion will only occur after the last recursion point has been reached (e.g. PrintNumbersFromOneToN)
 */
public class RecursionPractice
{
    public void PrintNumbersFromOneToN(int n)
    {
        if (n <= 0) return;
        PrintNumbersFromOneToN(n - 1);
        Console.WriteLine($"PrintNumbersFromOneToN: {n}");
    }

    public void PrintNumbersFromNToOne(int n)
    {
        if (n <= 0) return;
        Console.WriteLine($"PrintNumbersFromNToOne: {n}");
        PrintNumbersFromNToOne(n - 1);
    }

    public int CalculateFactorial(int n)
    {
        if (n <= 0) return 1;
        int result = n * CalculateFactorial(n - 1);
        Console.WriteLine($"CalculateFactorial: {result}");
        return result;
    }

    public int SumOfDigits(int n)
    {
        int lastDigit = n % 10;
        if (lastDigit == 0) return 0;
        int result = lastDigit + SumOfDigits(n / 10);
        Console.WriteLine($"SumOfDigits: {result}");
        return result;
    }

    public void IsPalindrome(string s)
    {
        char startChar = s[0];
        char endChar = s[s.Length - 1];
        if (startChar != endChar)
        {
            Console.WriteLine($"IsPalindrome: false");
            return;
        }

        if (startChar == endChar && s.Length <= 2)
        {
            Console.WriteLine($"IsPalindrome: true");
            return;
        }
        
        IsPalindrome(s.Substring(1, s.Length - 2));
    }

    public double PowerFunction(int x, int n)
    {
        double result;
        
        if (n == 0) result = 1.0;
        else if (n < 0) result = 1.0 / x * PowerFunction(x, n + 1);
        else result = x * PowerFunction(x, n - 1);
        
        Console.WriteLine($"PowerFunction: {result}");
        return result;
    }

    public int CountNumberOfZeroes(int n)
    {
        int result;
        int lastDigit = n % 10;
        if (n == 0) result = 0;
        else if (lastDigit == 0) result = 1 + CountNumberOfZeroes(n / 10);
        else result = 0 + CountNumberOfZeroes(n / 10);
        Console.WriteLine($"CountNumberOfZeroes: {result}");
        return result;
    }
}