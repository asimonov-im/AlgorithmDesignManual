namespace AlgorithmDesign.Algorithms
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Rolling hash modulo 2^32, using integer overflow.
    /// </summary>
    public class RollingHash2
    {
        public int Base { get; }

        public RollingHash2(int primeBase)
        {
            Base = primeBase;
        }

        public int Hash(string str) => Hash(str, 0, str.Length);

        public int Hash(string str, int startIndex, int length)
        {
            int hash = 0;
            int endIndex = startIndex + length;

            for (int i = startIndex; i < endIndex; ++i)
            {
                hash = hash * Base + str[i];
            }

            return hash;
        }

        public IEnumerable<(int idx, int hash)> Rolling(string str, int windowSize)
        {
            if (str.Length < windowSize)
            {
                throw new ArgumentException("The window size cannot exceed the length of the string.");
            }

            int hash = Hash(str, 0, windowSize);
            int baseExpN = BaseToExp(windowSize);

            yield return (0, hash);

            int end = str.Length - windowSize + 1;
            for (int i = 1; i < end; ++i)
            {
                hash = hash * Base + str[i + windowSize - 1];
                hash = hash - baseExpN * str[i - 1];

                yield return (i, hash);
            }
        }

        private int BaseToExp(int exp)
        {
            if (exp == 0) return 1;

            int x = BaseToExp(exp / 2);
            return exp % 2 == 0 ? x * x : x * x * Base;
        }
    }
}
