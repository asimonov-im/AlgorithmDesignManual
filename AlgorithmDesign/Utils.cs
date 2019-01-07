namespace AlgorithmDesign
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Swaps elements with indexA and indexB in the specified list.
    /// </summary>
    public static class Utils
    {
        public static void SwapElements<T>(this IList<T> lst, int indexA, int indexB)
        {
            T tmp = lst[indexA];
            lst[indexA] = lst[indexB];
            lst[indexB] = tmp;
        }

        public static void Reverse<T>(this IList<T> lst)
        {
            Reverse(lst, 0, lst.Count);
        }

        public static void Reverse<T>(this IList<T> lst, int startIndex, int count)
        {
            if (lst is List<T> list)
            {
                list.Reverse(startIndex, count);
            }
            else
            {
                int numSwaps = count / 2;
                for (int i = 0; i < numSwaps; ++i)
                {
                    SwapElements(lst, startIndex + i, lst.Count - 1 - i);
                }
            }
        }

        public static IEnumerable<List<T>> GetSubsets<T>(this IList<T> lst)
        {
            int subsetCount = 1 << lst.Count;
            for (int i = 0; i < subsetCount; ++i)
            {
                var subset = new List<T>();
                for (int j = 0; j < lst.Count; ++j)
                {
                    if (IsBitSet(i, j))
                    {
                        subset.Add(lst[j]);
                    }
                }

                yield return subset;
            }
        }

        public static bool IsBitSet(int num, int bitIndex)
        {
            return (num & (1 << bitIndex)) != 0;
        }
    }
}
