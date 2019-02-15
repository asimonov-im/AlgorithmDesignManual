namespace AlgorithmDesign.Exercises.Chapter7
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Permutations<T>
    {
        private IReadOnlyList<T> items;
        private List<int> partialSolution;

        public Permutations(IReadOnlyList<T> items)
        {
            this.items = items;
            this.partialSolution = new List<int>(items.Count);
        }

        public IEnumerable<List<T>> Get()
        {
            if (partialSolution.Count == items.Count)
            {
                yield return ConstructSolution();
            }
            else
            {
                foreach (var candidate in GetCandidates())
                {
                    partialSolution.Add(candidate);
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
            var inSolution = new BitArray(items.Count);
            foreach (var idx in partialSolution)
            {
                inSolution[idx] = true;
            }

            for (int i = 0; i < items.Count; ++i)
            {
                if (!inSolution[i]) yield return i;
            }
        }
    }
}
