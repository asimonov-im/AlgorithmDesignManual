namespace AlgorithmDesign.Exercises.Chapter3
{
    using System;

    public class ConstSearchInsertDelete
    {
        private readonly int[] A;
        private readonly int[] B;

        public int Count { get; private set; }

        /// <summary>
        /// Stores at most maxNumCount values, between 1 and maxN.
        /// Duplicates are not allowed.
        /// </summary>
        public ConstSearchInsertDelete(int maxN, int maxNumCount)
        {
            A = new int[maxN];
            B = new int[maxNumCount];
            Count = 0;
        }

        public bool Contains(int x)
        {
            CheckInRange(x);

            return Count > 0 &&
                   A[x - 1] < Count &&
                   B[A[x - 1]] == x;
        }

        public void Insert(int x)
        {
            if (Contains(x))
            {
                throw new InvalidOperationException("Insertion of duplicate values is not allowed.");
            }

            A[x - 1] = Count;
            B[Count] = x;
            ++Count;
        }

        public void Remove(int x)
        {
            // Move the last value inserted into the container into x's slot
            if (Contains(x))
            {
                int lastInsertedValue = B[Count - 1];
                int bIndexForX = A[x - 1];

                A[lastInsertedValue - 1] = bIndexForX;
                B[bIndexForX] = lastInsertedValue;
            }
        }

        private void CheckInRange(int x)
        {
            if (x < 1 || x > A.Length)
            {
                throw new InvalidOperationException("The specified value is out of range for the container.");
            }
        }
    }
}
