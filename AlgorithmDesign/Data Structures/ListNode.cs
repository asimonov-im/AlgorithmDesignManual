namespace AlgorithmDesign.DataStructures
{
    using System.Collections.Generic;

    public class ListNode<T>
    {
        public T Value { get; set; }

        public ListNode<T> Next { get; set; }

        public ListNode(T value)
        {
            Value = value;
        }

        public static ListNode<T> CreateList(IEnumerable<T> values)
        {
            ListNode<T> head = null;
            ListNode<T> tail = null;

            foreach (T value in values)
            {
                var node = new ListNode<T>(value);

                if (head == null)
                {
                    head = node;
                    tail = node;
                }
                else
                {
                    tail.Next = node;
                    tail = node;
                }
            }

            return head;
        }

        public static IEnumerable<T> AsEnumerable(ListNode<T> node)
        {
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }
    }
}
