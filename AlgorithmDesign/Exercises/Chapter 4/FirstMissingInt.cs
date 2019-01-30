namespace AlgorithmDesign.Exercises.Chapter4
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class FirstMissingInt
    {
        public static int Find(int[] values)
        {
            if (values.Length == 0) return 1;

            int low = 0;
            int high = values.Length - 1;
            while (true)
            {
                int mid = low + (high - low) / 2;
                if (values[low] > low + 1)
                {
                    return low + 1;
                }
                else if (values[mid] > mid + 1)
                {
                    high = mid;
                }
                else if (values[high] > high + 1)
                {
                    // values[low:mid] contains consecutive integers (low+1), (low+2), ..., (mid+1)
                    low = mid + 1;
                }
                else
                {
                    return high + 2;
                }
            }
        }
    }
}
