namespace AlgorithmDesign.Exercises.Chapter4
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using AlgorithmDesign.DataStructures;

    public static class SmallestSnippet
    {
        public class WordOccurances
        {
            public string Word { get; }

            /// <summary>
            /// Positions in the text, sorted in ascending order.
            /// </summary>
            public List<int> Positions { get; }

            public WordOccurances(string word)
            {
                Word = word ?? throw new ArgumentNullException(nameof(word));
                Positions = new List<int>();
            }
        }

        private class WordPosn : IEnumerator<int>
        {
            private IEnumerator<int> posnEnumerator;

            public string Word { get; }

            public int Current => posnEnumerator.Current;

            object IEnumerator.Current => posnEnumerator.Current;

            public bool MoveNext() => posnEnumerator.MoveNext();

            bool IEnumerator.MoveNext() => posnEnumerator.MoveNext();

            public void Reset() => posnEnumerator.Reset();

            public void Dispose() => posnEnumerator.Dispose();

            public WordPosn(WordOccurances w)
            {
                Word = w.Word;
                posnEnumerator = w.Positions.GetEnumerator();
            }
        }

        private class EnumeratorComparer : IComparer<List<int>.Enumerator>
        {
            public int Compare(List<int>.Enumerator x, List<int>.Enumerator y)
            {
                return x.Current.CompareTo(y.Current);
            }
        }

        public static (int, int) FindMinSpan(IReadOnlyList<WordOccurances> occurences)
        {
            var minSpan = (-1, -1);

            var heap = new MinMaxHeap<List<int>.Enumerator>(occurences.Count, new EnumeratorComparer());
            foreach (var occurence in occurences)
            {
                var wordPosn = occurence.Positions.GetEnumerator();
                if (!wordPosn.MoveNext())
                {
                    return minSpan;
                }

                heap.Insert(wordPosn);
            }

            while (true)
            {
                var first = heap.ExtractMin();
                var last = heap.PeekMax();
                var span = (first.Current, last.Current);

                if (minSpan == (-1, -1) ||
                    span.Item2 - span.Item1 < minSpan.Item2 - minSpan.Item1)
                {
                    minSpan = span;
                }

                if (!first.MoveNext()) break;

                heap.Insert(first);
            }

            return minSpan;
        }
    }
}
