namespace AlgorithmDesign.Exercises.Chapter7
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KElementSubsets<T>
    {
        private readonly int k;
        private readonly IReadOnlyList<T> items;
        private readonly List<int> partialSolution;
 
        public KElementSubsets(IReadOnlyList<T> items, int k)
        {
            if (k < 0) throw new ArgumentException("K must be positive.");

            this.k = k;
            this.items = items;
            partialSolution = new List<int>(k);
        }

        public IEnumerable<List<T>> Get()
        {
            if (partialSolution.Count == k)
            {
                yield return ConstructSolution();
            }
            else
            {
                foreach (var c in GetCandidates())
                {
                    partialSolution.Add(c);
                    foreach (var solution in Get())
                    {
                        yield return solution;
                    }
                    partialSolution.RemoveAt(partialSolution.Count - 1);
                }
            }
        }

        private List<T> ConstructSolution()
        {
            return partialSolution.Select(i => items[i]).ToList();
        }

        private IEnumerable<int> GetCandidates()
        {
            int lastIdx = partialSolution.Count > 0 ? partialSolution.Last() : -1;
            for (int i = lastIdx + 1; i < items.Count; ++i)
            {
                yield return i;
            }
        }
    }
}
