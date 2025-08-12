namespace collections_and_data_iteration_fundamentals;

public class SlidingWindow
{
    // Assumption 1: arr will always have at least k elements
    public int MaximumSumOfSubArray(int[] arr, int k)
    {
        int maxWindowSum = 0;
        int previousWindowSum = 0;
        int left = 0;
        int right = k - 1;

        while (right <= arr.Length - 1)
        {
            int currentWindowSum = 0;
            if (left == 0)
            {
                for (int i = 0; i < k; i++)
                {
                    currentWindowSum += arr[i];
                }
            }
            else
            {
                int previousValue = arr[left - 1];
                int nextValue = arr[right];
                currentWindowSum = previousWindowSum - previousValue + nextValue;
            }

            if (currentWindowSum > maxWindowSum)
            {
                maxWindowSum = currentWindowSum;
            }

            previousWindowSum = currentWindowSum;
            left++;
            right++;
        }

        return maxWindowSum;
    }

    public List<double> AverageOfSubArrays(int[] arr, int k)
    {
        List<double> result = new List<double>();
        int previousTotal = 0;
        int left = 0;
        int right = k - 1;

        while (right <= arr.Length - 1)
        {
            int currentTotal = 0;
            if (left == 0)
            {
                for (int i = 0; i < k; i++)
                {
                    currentTotal += arr[i];
                }
            }
            else
            {
                currentTotal = previousTotal + arr[right] - arr[left - 1];
            }
            
            result.Add(currentTotal * 1.0 / k);
            previousTotal = currentTotal;
            left++;
            right++;
        }

        return result;
    }

    public int LongestUniqueWindow(List<string> input)
    {
        Dictionary<string, int> indexesOfStrings = new Dictionary<string, int>();
        int maxWindow = 0;
        int left = 0;
        int right = 0;

        while (right <= input.Count)
        {
            int currentWindow = right - left;
            if (currentWindow > maxWindow)
            {
                maxWindow = currentWindow;
            }

            if (right == input.Count) break;
            if (indexesOfStrings.ContainsKey(input[right]))
            {
                left = Math.Max(left, indexesOfStrings[input[right]] + 1); // Required for edge cases where left pointer might slide back down from the current position (e.g. ["A", "B", "C", "B", "B", "C", "D"])
            }
            indexesOfStrings[input[right]] = right;
            right++;
        }

        return maxWindow;
    }

    public bool DetectDDoSAttack(int[] timestamps, int t, int n)
    {
        int maxTime = timestamps[0] + t - 1;
        int windowStart = 0;
        int windowEnd = 0;

        while (windowEnd <= timestamps.Length)
        {
            if (windowEnd - windowStart > n)
            {
                return true;
            }

            if (windowEnd == timestamps.Length)
            {
                break;
            }
            
            if (maxTime >= timestamps[windowEnd])
            {
                windowEnd++;
            }
            else
            {
                maxTime = timestamps[windowEnd] + t - 1;
                windowStart = windowEnd;
            }
        }

        return false;
    }

    public List<int> FindMaximumInSubArrayOfKElements(int[] nums, int k)
    {
        int left = 0;
        int right = 0;
        LinkedList<int> indices = new LinkedList<int>();
        List<int> result = new List<int>();

        while (right < nums.Length)
        {
            while (indices.Count > 0 && left > indices.First.Value)
            {
                indices.RemoveFirst();
            }
            
            while (indices.Count > 0 && nums[right] > nums[indices.Last.Value])
            {
                indices.RemoveLast();
            }
            indices.AddLast(right);
            
            if (right - left == k - 1)
            {
                result.Add(nums[indices.First.Value]);
                left++;
            }
            right++;
        }

        return result;
    }

    public List<int> WarmestCoffeeInTheLastXMinutes(int[] temps, int x)
    {
        int left = 0; // start of window
        int right = 0; // end of window
        List<int> result = new List<int>(); // output
        LinkedList<int> indices = new LinkedList<int>(); // used to keep track of the largest temperature in current sliding window
        
        while (right < temps.Length) // used to ensure that every possible sub-array/sliding window from temps is formed
        {
            // checks and removes any indices in the deque that are out of the current sliding window
            while (indices.Count > 0 && left > indices.First.Value)
            {
                indices.RemoveFirst(); 
            }

            // checks and removes any indices in the deque containing past temperatures that are smaller than the current temperature
            while (indices.Count > 0 && temps[right] > temps[indices.Last.Value])
            {
                indices.RemoveLast();
            }
            indices.AddLast(right);

            // if number of elements in sliding window = x, assign the maximum temperature found in the sliding window by taking the first most value of the 
            // move the left and right pointer up so that a new sub-array/sliding window containing x elements is formed
            if (right - left == x - 1)
            {
                result.Add(temps[indices.First.Value]);
                left++;
            }
            right++; // do nothing and only move to the right pointer up if the number of elements inside the sub-array/sliding window is not equal to x elements
        }

        return result;
    }

    public int MaximumAveragePlayerScoreOverA7DayStreak(int[] scores)
    {
        int left = 0; // start window
        int right = 6; // end window, 7 day streak so our initial window will have 7 elements, hence right = 7 - 1 = 6 -> 0, 1, 2, 3, 4, 5, 6 -> 7 elements
        int maxAverage = 0;
        int total = 0;

        while (right < scores.Length)
        {
            int currentMaxAverage = 0;
            if (right ==  7 - 1)
            {
                for (int i = 0; i <= right; i++)
                {
                    total += scores[i];
                }

                currentMaxAverage = total / 7;
            }
            else
            {
                currentMaxAverage = (total - scores[left - 1] + scores[right]) / 7;
            }

            if (currentMaxAverage > maxAverage) maxAverage = currentMaxAverage;
            left++;
            right++;
        }

        return maxAverage;
    }
}