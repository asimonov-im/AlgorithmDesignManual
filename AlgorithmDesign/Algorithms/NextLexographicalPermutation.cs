namespace AlgorithmDesign.Algorithms
{
    using System;
    using System.Collections.Generic;

    public static class NextLexographicalPermutation
    {
        public static bool NextPermutation<T>(this IList<T> lst)
        {
            return NextPermutation(lst, Comparer<T>.Default);
        }

        public static bool NextPermutation<T>(this IList<T> lst, Comparison<T> comparison)
        {
            return NextPermutation(lst, Comparer<T>.Create(comparison));
        }

        public static bool NextPermutation<T>(this IList<T> lst, IComparer<T> comparer)
        {
            if (lst.Count < 2) return false;

            // Find the longest non-increasing suffix of the sequence.
            // The pivot is the element immediately to the left of the suffix.
            //
            // In 0125330 the suffix is 5330 and the pivot is 2
            // In 0124656 the suffix is 6 and the pivot is 5
            // In 7654321 the suffix is the entire sequence and there is no pivot
            int p = lst.Count - 2;
            for (; p >= 0 && comparer.Compare(lst[p], lst[p + 1]) >= 0; --p);

            // Check if the sequence is the last permutation
            if (p < 0) return false;

            // In the suffix, find the right-most value greater than the pivot.
            int v = lst.Count - 1;
            for (; comparer.Compare(lst[p], lst[v]) >= 0; --v);

            // Swap the pivot and the value and reverse the suffix.
            lst.SwapElements(p, v);
            lst.Reverse(p + 1, lst.Count - p - 1);

            return true;
        }
    }
}
