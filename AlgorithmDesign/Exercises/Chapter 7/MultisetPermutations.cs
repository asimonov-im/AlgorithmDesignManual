namespace AlgorithmDesign.Exercises.Chapter7
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class MultisetPermutations<T>
    {
        private IReadOnlyList<T> items;
        private List<int> partialSolution;

        public MultisetPermutations(IReadOnlyList<T> items)
        {
            this.items = items;
            partialSolution = new List<int>(items.Count);
        }

        public IEnumerable<List<T>> Get()
        {
            if (partialSolution.Count == items.Count)
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

        private IEnumerable<int> GetCandidates()
        {
            var inSolution = new BitArray(items.Count);
            foreach (var idx in partialSolution)
            {
                inSolution[idx] = true;
            }

            // Eliminate duplicates from the candidate set
            var candidateValues = new HashSet<T>();
            for (int i = 0; i < items.Count; ++i)
            {
                if (!inSolution[i] && candidateValues.Add(items[i]))
                {
                    yield return i;
                }
            }
        }

        private List<T> ConstructSolution()
        {
            return partialSolution.Select(i => items[i]).ToList();
        }
    }

    public class MultisetPermutations_V2<T>
    {
        private IReadOnlyList<T> items;
        private List<T> partialSolution;
        private Dictionary<T, int> candidates;

        public MultisetPermutations_V2(IReadOnlyList<T> items)
        {
            this.items = items;
            partialSolution = new List<T>(items.Count);

            candidates = new Dictionary<T, int>();
            foreach (var item in items)
            {
                candidates.TryGetValue(item, out int count);
                candidates[item] = count + 1;
            }
        }

        public IEnumerable<List<T>> Get()
        {
            if (partialSolution.Count == items.Count)
            {
                yield return ConstructSolution();
            }
            else
            {
                foreach (var c in GetCandidates())
                {
                    AddCandidateToSolution(c);
                    foreach (var solution in Get())
                    {
                        yield return solution;
                    }
                    RemoveCandidateFromSolution(c);
                }
            }
        }

        private IEnumerable<T> GetCandidates()
        {
            return candidates.Keys.ToList();
        }

        private List<T> ConstructSolution()
        {
            return partialSolution.ToList();
        }

        private void AddCandidateToSolution(T c)
        {
            partialSolution.Add(c);

            int count = candidates[c];
            if (count > 1)
            {
                candidates[c] = count - 1;
            }
            else
            {
                candidates.Remove(c);
            }
        }

        private void RemoveCandidateFromSolution(T c)
        {
            partialSolution.RemoveAt(partialSolution.Count - 1);

            candidates.TryGetValue(c, out int count);
            candidates[c] = count + 1;
        }
    }
}
