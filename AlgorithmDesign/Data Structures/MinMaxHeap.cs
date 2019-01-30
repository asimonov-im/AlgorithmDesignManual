namespace AlgorithmDesign.DataStructures
{
    using System;
    using System.Collections.Generic;

    public class MinMaxHeap<T>
    {
        private readonly List<T> values;
        private readonly IComparer<T> comparer;
        private readonly IComparer<T> reverseComparer;

        public int Count => values.Count;

        public MinMaxHeap(int n)
            : this(n, Comparer<T>.Default)
        {
        }

        public MinMaxHeap(IEnumerable<T> values)
            : this(values, Comparer<T>.Default)
        {
        }

        public MinMaxHeap(int n, IComparer<T> comparer)
        {
            this.values = new List<T>(n);
            this.comparer = comparer;
            this.reverseComparer = new ReverseComparer<T>(comparer);
        }

        public MinMaxHeap(IEnumerable<T> values, IComparer<T> comparer)
        {
            this.values = new List<T>(values);
            this.comparer = comparer;
            this.reverseComparer = new ReverseComparer<T>(comparer);

            // Skip all leaf nodes
            for (int i = Parent(Count - 1); i >= 0; --i)
            {
                BubbleDown(i);
            }
        }

        private MinMaxHeap(List<T> values, IComparer<T> comparer, IComparer<T> reverseComparer)
        {
            this.values = values;
            this.comparer = comparer;
            this.reverseComparer = reverseComparer;
        }

        public T PeekMin() => values[GetMinIndex()];

        public T PeekMax() => values[GetMaxIndex()];

        public T ExtractMin() => RemoveValueAt(GetMinIndex());

        public T ExtractMax() => RemoveValueAt(GetMaxIndex());

        public void Insert(T value)
        {
            values.Add(value);
            BubbleUp(values.Count - 1);
        }

        public MinMaxHeap<T> ShallowCopy()
        {
            return new MinMaxHeap<T>(
                new List<T>(values),
                comparer,
                reverseComparer);
        }

        private T RemoveValueAt(int idx)
        {
            T value = values[idx];
            values[idx] = values[Count - 1];
            values.RemoveAt(Count - 1);

            BubbleDown(idx);

            return value;
        }

        private int GetMinIndex()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The heap is empty.");
            }

            return 0;
        }

        private int GetMaxIndex()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The heap is empty.");
            }

            int maxIdx = Count - 1;
            if (Count > 2)
            {
                if (comparer.Compare(values[2], values[1]) > 0)
                    maxIdx = 2;
                else
                    maxIdx = 1;
            }

            return maxIdx;
        }

        private IComparer<T> GetComparer(int idx)
            => IsOnMinLevel(idx) ? comparer : reverseComparer;

        private IComparer<T> GetAltComparer(int idx)
            => IsOnMinLevel(idx) ? reverseComparer : comparer;

        private void BubbleUp(int idx)
        {
            IComparer<T> comparer = GetComparer(idx);
            IComparer<T> altComparer = GetAltComparer(idx);

            int parent = Parent(idx);
            if (parent >= 0 &&
                comparer.Compare(values[idx], values[parent]) > 0)
            {
                Swap(idx, parent);
                BubbleUp(parent, altComparer);
            }
            else
            {
                BubbleUp(idx, comparer);
            }
        }

        private void BubbleUp(int idx, IComparer<T> comparer)
        {
            int grandparent = Parent(Parent(idx));
            if (grandparent >= 0 &&
                comparer.Compare(values[idx], values[grandparent]) < 0)
            {
                Swap(idx, grandparent);
                BubbleUp(grandparent, comparer);
            }
        }

        private void BubbleDown(int root)
        {
            IComparer<T> comparer = GetComparer(root);
            BubbleDown(root, comparer);
        }

        private void BubbleDown(int root, IComparer<T> comparer)
        {
            int minIdx = MinOfSubtree(root, comparer);
            if (minIdx == root) return;

            int minParent = Parent(minIdx);
            if (minParent == root)
            {
                Swap(root, minIdx);
            }
            else /* minIdx is a grandchild */
            {
                Swap(root, minIdx);
                if (comparer.Compare(values[minIdx], values[minParent]) > 0)
                {
                    Swap(minIdx, minParent);
                }
                BubbleDown(minIdx, comparer);
            }
        }

        private int MinOfSubtree(int root, IComparer<T> comparer)
        {
            int minIdx = root;

            int firstChild = LeftChild(root);
            if (firstChild < Count)
            {
                int lastChild = Math.Min(Count - 1, firstChild + 1);
                for (int i = firstChild; i <= lastChild; ++i)
                {
                    if (comparer.Compare(values[i], values[minIdx]) < 0)
                        minIdx = i;
                }

                int firstGrandchild = LeftChild(firstChild);
                if (firstGrandchild < Count)
                {
                    int lastGrandchild = Math.Min(Count - 1, firstGrandchild + 3);
                    for (int i = firstGrandchild; i <= lastGrandchild; ++i)
                    {
                        if (comparer.Compare(values[i], values[minIdx]) < 0)
                            minIdx = i;
                    }
                }
            }

            return minIdx;
        }

        /// <summary>
        /// Swaps the value at index i, with the value at index j.
        /// </summary>
        private void Swap(int i, int j)
        {
            T tmp = values[i];
            values[i] = values[j];
            values[j] = tmp;
        }

        private static bool IsOnMinLevel(int i)
        {
            // Even levels are min-levels
            // Odd levels arer max-levels
            int treeLevel = (int)Math.Log(i + 1, 2);
            return treeLevel % 2 == 0;
        }

        private static int LeftChild(int parentIdx)
            => parentIdx * 2 + 1;

        private static int Parent(int childIdx)
        {
            if (childIdx > 0)
                return (childIdx - 1) / 2;
            else
                return -1;
        }
    }
}
