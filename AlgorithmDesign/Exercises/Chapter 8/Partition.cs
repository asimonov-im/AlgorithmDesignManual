namespace AlgorithmDesign.Exercises.Chapter8
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Partition
    {
        private int[,] DP;
        private int[,] P;
        private int[] prefixSum;

        private readonly IReadOnlyList<int> values;
        private readonly int k;

        private void Init()
        {
            DP = new int[values.Count, k];
            P = new int[values.Count, k];
            prefixSum = new int[values.Count];

            prefixSum[0] = values[0];
            for (int i = 1; i < values.Count; ++i)
            {
                prefixSum[i] = prefixSum[i - 1] + values[i];
            }

            // Base case: partitioning values into a single range
            for (int i = 0; i < values.Count; ++i)
            {
                DP[i, 0] = prefixSum[i];
            }

            // Base case: partitioning a single value
            for (int i = 0; i < k; ++i)
            {
                DP[0, i] = values[0];
            }
        }

        public Partition(IReadOnlyList<int> values, int k)
        {
            this.values = values;
            this.k = k;
        }

        public List<int> Get()
        {
            // Let DP[n, k] be the minimum possible cost of all partitionings of the first
            // (n + 1) values into (k + 1) ranges, where the cost of a partition is the largest
            // sum of elements in one of its parts.
            Init();

            for (int i = 1; i < values.Count; ++i)
            {
                for (int j = 1; j < k; ++j)
                {
                    // Partition the first m elements into j ranges
                    DP[i, j] = int.MaxValue;
                    for (int m = 0; m < i; ++m)
                    {
                        int cost = Math.Max(DP[m, j - 1], prefixSum[i] - prefixSum[m]);
                        if (cost < DP[i, j])
                        {
                            DP[i, j] = cost;
                            P[i, j] = m;
                        }
                    }
                }
            }

            return ConstructSolution();
        }

        private List<int> ConstructSolution()
        {
            var result = new List<int>(k);

            int n = values.Count - 1;
            for (int k = this.k - 1; k > 0 && n > 0; --k)
            {
                result.Add(P[n, k]);
                n = P[n, k];
            }

            result.Reverse();

            return result;
        }
    }
}
