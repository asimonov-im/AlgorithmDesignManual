namespace AlgorithmDesign.Data_Structures
{
    using System;

    public struct Interval<T> : IComparable<Interval<T>>, IComparable
        where T : IComparable<T>
    {
        public T Start { get; private set; }

        public T End { get; private set; }

        public Interval(T start, T end)
        {
            if (start.CompareTo(end) > 0)
            {
                throw new ArgumentException("Start must be <= end.");
            }

            Start = start;
            End = end;
        }

        public int CompareTo(Interval<T> other)
        {
            int startResult = this.Start.CompareTo(other.Start);
            return startResult == 0 ? this.End.CompareTo(other.End) : startResult;
        }

        int IComparable.CompareTo(object obj)
        {
            if (obj is Interval<T> otherInterval)
            {
                return this.CompareTo(otherInterval);
            }

            throw new InvalidOperationException("Other object is not an Interval.");
        }

        public static bool AreDisjoint(Interval<T> a, Interval<T> b)
        {
            if (a.Start.CompareTo(b.Start) > 0)
            {
                return AreDisjoint(b, a);
            }

            return a.End.CompareTo(b.Start) <= 0;
        }
    }
}
