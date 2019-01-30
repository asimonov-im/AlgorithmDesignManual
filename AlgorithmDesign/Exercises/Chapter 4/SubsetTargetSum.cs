namespace AlgorithmDesign.Exercises.Chapter4
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public static class SubsetTargetSum
    {
        public static IEnumerable<(int, int)> Sum2(IReadOnlyList<int> values, int target)
        {
            BitArray ignored = new BitArray(values.Count, false);
            return Sum2Impl(values, target, 0);
        }

        private static IEnumerable<(int, int)> Sum2Impl(IReadOnlyList<int> values, int target, int startIndex)
        {
            int i = startIndex;
            int j = values.Count - 1;
            while (i < j)
            {
                int sum = values[i] + values[j];
                if (sum < target)
                {
                    ++i;
                }
                else if (sum > target)
                {
                    --j;
                }
                else
                {
                    yield return (i, j);
                    ++i;
                    --j;
                }
            }
        }

        public static IEnumerable<(int, int, int)> Sum3(IReadOnlyList<int> values, int target)
        {
            for (int i = 0; i < values.Count - 2; ++i)
            {
                var twoSums = Sum2Impl(values, target - values[i], i + 1);
                foreach (var result in twoSums)
                {
                    yield return (i, result.Item1, result.Item2);
                }
            }
        }

        public static bool SumK(IReadOnlyList<int> values, int target, int k)
        {
            return SumKImpl(values, target, k, 0);
        }

        private static bool SumKImpl(IReadOnlyList<int> values, int target, int k, int startIndex)
        {
            if (k == 2)
                return Sum2Impl(values, target, startIndex).Any();

            int endIndex = values.Count - k;
            for (int i = startIndex; i <= endIndex; ++i)
            {
                if (SumKImpl(values, target - values[i], k - 1, i + 1))
                    return true;
            }

            return false;
        }
    }
}
