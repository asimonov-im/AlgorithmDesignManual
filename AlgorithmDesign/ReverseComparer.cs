namespace AlgorithmDesign
{
    using System.Collections.Generic;

    public sealed class ReverseComparer<T> : IComparer<T>
    {
        private readonly IComparer<T> comparer = Default;

        public static readonly ReverseComparer<T> Default =
            new ReverseComparer<T>(Comparer<T>.Default);

        public ReverseComparer(IComparer<T> comparer)
            => this.comparer = comparer;

        public int Compare(T x, T y)
            => comparer.Compare(y, x);
    }
}
