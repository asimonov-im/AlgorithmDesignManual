namespace AlgorithmDesign.DataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Heap<T>
    {
        private T[] values;
        private IComparer<T> comparer;

        public int Count { get; private set; }

        public Heap(int n)
            : this(n, Comparer<T>.Default)
        {
        }

        public Heap(IEnumerable<T> values)
            : this (values, Comparer<T>.Default)
        {
        }

        public Heap(int n, IComparer<T> comparer)
        {
            this.values = new T[n];
            this.comparer = comparer;
        }

        public Heap(IEnumerable<T> values, IComparer<T> comparer)
        {
            this.values = values.ToArray();
            this.Count = this.values.Length;
            this.comparer = comparer;

            // Skip heapifying leaf nodes
            for (int i = Parent(Count - 1); i >= 0; --i)
            {
                BubbleDown(i);
            }
        }

        public void Insert(T value)
        {
            if (values.Length == Count)
            {
                Array.Resize(ref values, Count * 2);
            }

            values[Count] = value;
            ++Count;
            BubbleUp();
        }

        public T ExtractMin()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The heap is empty.");
            }

            --Count;
            Swap(0, Count);
            BubbleDown(0);

            return values[Count];
        }

        /// <summary>
        /// Returns true is the value at index i dominates the value at index j.
        /// </summary>
        private bool Dominates(int i, int j)
            => comparer.Compare(values[i], values[j]) < 0;

        /// <summary>
        /// Swaps the value at index i, with the value at index j.
        /// </summary>
        private void Swap(int i, int j)
        {
            T tmp = values[i];
            values[i] = values[j];
            values[j] = tmp;
        }

        /// <summary>
        /// Bubbles up the last inserted element, restoring the heap.
        /// </summary>
        private void BubbleUp()
        {
            int current = Count - 1;
            int parent = Parent(current);

            while (current > 0 && Dominates(current, parent))
            {
                Swap(current, parent);

                current = parent;
                parent = Parent(current);
            }
        }

        private void BubbleDown(int parent)
        {
            int dominantIdx = parent;
            bool childIsDominant = true;

            while (childIsDominant)
            {
                int leftChild = LeftChild(parent);
                int rightChild = RightChild(parent);
                for (int c = leftChild; c < Count && c <= rightChild; ++c)
                {
                    if (Dominates(c, dominantIdx)) dominantIdx = c;
                }

                childIsDominant = (dominantIdx != parent);
                if (childIsDominant)
                {
                    Swap(dominantIdx, parent);
                    parent = dominantIdx;
                }
            }
        }

        private static int Parent(int childIdx) => (childIdx - 1) / 2;
        private static int LeftChild(int parentIdx) => parentIdx * 2 + 1;
        private static int RightChild(int parentIdx) => parentIdx * 2 + 2;
        private static int InternalNodeCount(int n) => (1 << (int)Math.Log(n, 2)) - 1;
    }
}
