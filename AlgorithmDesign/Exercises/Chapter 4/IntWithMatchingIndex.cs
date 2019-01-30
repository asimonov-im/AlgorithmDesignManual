namespace AlgorithmDesign.Exercises.Chapter4
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class IntWithMatchingIndex
    {
        public static int Find(int[] values)
        {
            int low = 0;
            int high = values.Length - 1;
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (values[mid] < mid)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }
            }

            if (low == high && values[low] == low)
                return low;
            else
                return -1;
        }
    }
}
