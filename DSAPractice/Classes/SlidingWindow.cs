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
}