namespace AlgorithmDesign.Exercises.Chapter4
{
    using System;

    public static class CircularShift
    {
        /// <summary>
        /// Returns the index of the largest element in the array.
        /// </summary>
        public static int FindMaxIndex(int[] shiftedValues)
        {
            int low = 0;
            int high = shiftedValues.Length - 1;
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (shiftedValues[mid] < shiftedValues[low])
                {
                    high = mid - 1;
                }
                else if (shiftedValues[mid] < shiftedValues[high])
                {
                    low = mid + 1;
                }
                else
                {
                    low = mid;
                    high = mid;
                }
            }

            return high;
        }

        /// <summary>
        /// Returns the index of the smallest element in the array.
        /// This is also the right shift, except when the array is empty.
        /// </summary>
        public static int FindMinIndex(int[] shiftedValues)
        {
            int low = 0;
            int high = shiftedValues.Length - 1;
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (shiftedValues[mid] > shiftedValues[high])
                {
                    low = mid + 1;
                }
                else if (shiftedValues[mid] > shiftedValues[low])
                {
                    high = mid - 1;
                }
                else
                {
                    high = low;
                }
            }

            return high;
        }

        public static void RightShift_InPlace<T>(T[] values, int k)
        {
            k = values.Length < 2 ? 0 : Utils.Mod(k, values.Length);

            if (k > 0)
            {
                T savedValue = values[0];
                int savedValueIdx = 0;
                for (int i = 0; i < values.Length; ++i)
                {
                    int nextIdx = Utils.Mod(savedValueIdx + k, values.Length);
                    Utils.Swap(ref savedValue, ref values[nextIdx]);
                    savedValueIdx = nextIdx;
                }
            }
        }

        public static T[] RightShift<T>(T[] values, int k)
        {
            k = values.Length < 2 ? 0 : Utils.Mod(k, values.Length);

            T[] result;
            if (k == 0)
            {
                result = (T[])values.Clone();
            }
            else
            {
                result = new T[values.Length];
                Array.Copy(values, 0, result, k, values.Length - k);
                Array.Copy(values, values.Length - k, result, 0, k);
            }

            return result;
        }
    }
}
