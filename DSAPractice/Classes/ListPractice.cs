namespace collections_and_data_iteration_fundamentals;

public class ListPractice
{
    public void QuestionOne()
    {
        Console.WriteLine("Create a List<string> of pet names. Add 5 names to the list. Print them all using a foreach loop.");
        List<string> petNames = new List<string> {"max", "maxine", "maxi", "maximum", "bob"};
        foreach (string petName in petNames)
        {
            Console.WriteLine(petName);
        }
    }

    public void QuestionTwo(List<int> numbers)
    {
        Console.WriteLine("Write a method that takes a List<int> and prints the average of all numbers.");
        if (numbers == null || numbers.Count == 0)
        {
            Console.WriteLine("No numbers found");
        }

        int total = 0;
        foreach (int number in numbers)
        {
            total += number;
        }

        Console.WriteLine(total/numbers.Count);
    }

    public void QuestionThree(List<int> numbers)
    {
        Console.WriteLine("Sort a list of numbers in descending order.");

        // Sort method -> O(n log n) time complexity
        List<int> numbersBySortMethod = numbers;
        numbersBySortMethod.Sort((a, b) => b.CompareTo(a));
        Console.Write("Sort method: ");
        foreach (int numberBySortMethod in numbersBySortMethod)
        {
            Console.Write($"{numberBySortMethod} ");
        }
        Console.WriteLine();

        // LINQ method -> O(n log n) time complexity
        List<int> numbersByLinqMethod = numbers.OrderByDescending(n => n).ToList();
        Console.Write("LINQ method: ");
        foreach (int numberByLinqMethod in numbersByLinqMethod)
        {
            Console.Write($"{numberByLinqMethod} ");
        }
        Console.WriteLine();
        
        // Bucket sorting method
        int highestNumber = 0;
        int smallestNumber = 0;
        foreach (int number in numbers)
        {
            if (number > highestNumber)
            {
                highestNumber = number;
                continue;
            }
            if (number < smallestNumber) smallestNumber = number;
        }

        List<List<int>> bucket = new List<List<int>>();
        for (int i = 0; i < highestNumber - smallestNumber + 1; i++)
        {
            bucket.Add(new List<int>());
        }

        foreach (int number in numbers)
        {
            bucket[number - smallestNumber].Add(number); // Ensures that minimum index is always zero
        }

        List<int> numbersByBucketSortingMethod = new List<int>();
        for (int i = bucket.Count - 1; i >= 0; i--)
        {
            for (int j = 0; j < bucket[i].Count; j++)
            {
                numbersByBucketSortingMethod.Add(bucket[i][j]);
            }
        }

        Console.Write("Bucket sorting method: ");
        foreach (int number in numbersByBucketSortingMethod)
        {
            Console.Write($"{number} ");
        }
    }
}