namespace AlgorithmDesign.Data_Structures
{
    using System;

    public struct Interval<T> : IEquatable<Interval<T>>, IComparable<Interval<T>>, IComparable
        where T : IComparable<T>, IEquatable<T>
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

        public bool Contains(Interval<T> other)
        {
            return Start.CompareTo(other.Start) <= 0 && End.CompareTo(other.End) >= 0;
        }

        public override bool Equals(object other)
        {
            if (other is Interval<T> otherInterval)
            {
                return this.Equals(otherInterval);
            }

            return false;
        }

        public bool Equals(Interval<T> other)
        {
            return Start.Equals(other.Start) && End.Equals(other.End);
        }

        public override int GetHashCode()
        {
            return Start.GetHashCode() * 17 + End.GetHashCode();
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

        public static bool operator ==(Interval<T> i1, Interval<T> i2) => i1.Equals(i2);

        public static bool operator !=(Interval<T> i1, Interval<T> i2) => !i1.Equals(i2);

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
