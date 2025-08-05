namespace collections_and_data_iteration_fundamentals;

public class BinarySearchPractice
{
    public int FindMaxDownloadableFileSize(int[] fileSizes, int maxSize)
    {
        int result = -1;
        int left = 0;
        int right = fileSizes.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2; // algebraically same as (left + right) / 2, used to prevent integer overflow
            if (fileSizes[mid] <= maxSize)
            {
                result = mid;
                left = mid + 1;
                continue;
            }

            if (fileSizes[mid] > maxSize)
            {
                right = mid - 1;
            }
        }

        return result;
    }

    public int FindMinimumPassingTimeout(int low, int high)
    {
        int result = -1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;

            if (!DoesRequestSucceed(mid))
            {
                low = mid + 1;
            }
            else
            {
                result = mid;
                high = mid - 1;
            }
        }

        return result;
    }

    public long FindFirstRequestAtOrAfter(long[] timestamps, long cutoff)
    {
        int result = -1;
        int left = 0;
        int right = timestamps.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (timestamps[mid] >= cutoff)
            {
                result = mid;
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return result;
    }

    public int GetPageStartIndex(int[] sortedItemIds, int targetId)
    {
        int result = -1;
        int left = 0;
        int right = sortedItemIds.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (sortedItemIds[mid] < targetId)
            {
                left = mid + 1;
            }
            else
            {
                result = mid;
                right = mid - 1;
            }
        }

        return result;
    }

    public int FindFirstDayWithHighAverage(double[] readings, double threshold)
    {
        int result = -1;
        int left = 0;
        int right = readings.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (readings[mid] >= threshold)
            {
                result = mid;
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return result;
    }
    
    private bool DoesRequestSucceed(int timeout)
    {
        return timeout >= 450;
    }
}