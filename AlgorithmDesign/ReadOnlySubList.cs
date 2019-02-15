namespace AlgorithmDesign
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReadOnlySubList<T> : IReadOnlyList<T>
    {
        private readonly IReadOnlyList<T> list;
        private readonly int first;
        private readonly int last;

        public T this[int index] => list[first + index];

        public int Count => last - first + 1;

        public ReadOnlySubList(IReadOnlyList<T> list, int first, int last)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (last < 0 || last >= list.Count) throw new ArgumentOutOfRangeException(nameof(last));
            if (first < 0 || first > last) throw new ArgumentOutOfRangeException(nameof(first));

            if (list is ReadOnlySubList<T> sublist)
            {
                this.list = sublist.list;
                this.first = sublist.first + first;
                this.last = sublist.first + last;
            }
            else
            {
                this.list = list;
                this.first = first;
                this.last = last;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator(list, first, last);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private struct ListEnumerator : IEnumerator<T>
        {
            private readonly IReadOnlyList<T> list;
            private readonly int first;
            private readonly int last;
            private int current;

            public T Current
            {
                get
                {
                    if (current < first || current > last)
                    {
                        throw new InvalidOperationException();
                    }

                    return list[current];
                }
            }

            object IEnumerator.Current => Current;

            public ListEnumerator(IReadOnlyList<T> list, int first, int last)
            {
                this.list = list;
                this.first = first;
                this.last = last;
                this.current = first - 1;
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                ++current;
                return current <= last;
            }

            public void Reset()
            {
                current = first - 1;
            }
        }
    }
}
