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

    public int ECommerceSalesStreak(int[] revenue, int k)
    {
        int left = 0;
        int right = k - 1;
        int maxTotalRevenue = 0;
        int currentTotalRevenue = 0;

        while (right < revenue.Length)
        {
            if (right == k - 1)
            {
                for (int i = 0; i <= right; i++)
                {
                    currentTotalRevenue += revenue[i];
                }
            }
            else
            {
                currentTotalRevenue = currentTotalRevenue - revenue[left - 1] + revenue[right];
            }

            if (currentTotalRevenue > maxTotalRevenue)
            {
                maxTotalRevenue = currentTotalRevenue;
            }
            
            left++;
            right++;
        }

        return maxTotalRevenue;
    }

    public int LongestUniqueBrowsingSession(int[] pages)
    {
        int left = 0;
        int right = 0;
        int longestUniqueWindow = 0;
        Dictionary<int, int> visitedPages = new Dictionary<int, int>();

        while (right < pages.Length)
        {
            if (visitedPages.ContainsKey(pages[right]))
            {
                left = visitedPages[pages[right]] + 1;
            }
            int currentLongestUniqueWindow = right - left + 1;
            visitedPages[pages[right]] = right;
            right++;

            if (currentLongestUniqueWindow > longestUniqueWindow)
            {
                longestUniqueWindow = currentLongestUniqueWindow;
            }
        }

        return longestUniqueWindow;
    }

    public List<int> MaximumTemperatureInLastKHours(int[] temps, int k)
    {
        int left = 0;
        int right = 0;
        LinkedList<int> indexOfMaximumTemperatures = new LinkedList<int>();
        List<int> result = new List<int>();

        while (right < temps.Length)
        {
            while (indexOfMaximumTemperatures.Count > 0 && left > indexOfMaximumTemperatures.First.Value)
            {
                indexOfMaximumTemperatures.RemoveFirst();
            }

            while (indexOfMaximumTemperatures.Count > 0 && temps[right] > temps[indexOfMaximumTemperatures.Last.Value])
            {
                indexOfMaximumTemperatures.RemoveLast();
            }

            indexOfMaximumTemperatures.AddLast(right);

            if (right - left == k - 1)
            {
                result.Add(temps[indexOfMaximumTemperatures.First.Value]);
                left++;
            }

            right++;
        }

        return result;
    }

    public int MinConsecutiveDaysToHitDataCapUsage(int[] usage, int cap)
    {
        int left = 0;
        int right = 0;
        int sum = 0;
        int minConsecutiveDaysToHitCap = int.MaxValue;

        while (right < usage.Length)
        {
            sum += usage[right];
            while (sum >= cap)
            {
                minConsecutiveDaysToHitCap = Math.Min(minConsecutiveDaysToHitCap, right - left + 1);
                sum -= usage[left];
                left++;
            }
            right++;
        }

        return minConsecutiveDaysToHitCap == int.MaxValue ? 0 : minConsecutiveDaysToHitCap;
    }

    public int MaxConsecutiveSequenceOfCustomerWaitTime(int[] waitTime, int serviceLimit)
    {
        int left = 0;
        int right = 0;
        int sum = 0;
        int maxConsecutiveSequence = 0;

        while (right < waitTime.Length)
        {
            sum += waitTime[right];
            while (sum > serviceLimit)
            {
                sum -= waitTime[left];
                left++;
            }
            
            maxConsecutiveSequence = Math.Max(maxConsecutiveSequence, right - left + 1);
            right++;
        }

        return maxConsecutiveSequence;
    }

    public double LargestPercentageIncrease(int[] nums, int k)
    {
        int left = 0;
        int right = k - 1;
        int previousTotal = 0;
        double largestPercentageIncrease = 0;

        while (right < nums.Length)
        {
            int currentTotal = 0;
            double currentPercentageIncrease = 0;
            if (right == k - 1)
            {
                for (int i = 0; i <= right; i++)
                {
                    currentTotal += nums[i];
                }
            }
            else
            {
                currentTotal = previousTotal - nums[left - 1] + nums[right];
                currentPercentageIncrease = (currentTotal - previousTotal) * 1.0 / previousTotal * 100;
            }

            if (currentPercentageIncrease > largestPercentageIncrease)
            {
                largestPercentageIncrease = currentPercentageIncrease;
            }

            previousTotal = currentTotal;
            left++;
            right++;
        }

        return largestPercentageIncrease;
    }
}