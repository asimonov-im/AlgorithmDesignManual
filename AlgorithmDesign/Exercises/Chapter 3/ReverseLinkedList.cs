namespace AlgorithmDesign.Exercises.Chapter3
{
    using AlgorithmDesign.DataStructures;

    public class ReverseLinkedList
    {
        public static ListNode<T> Reverse_Recursive<T>(ListNode<T> lst)
        {
            return Reverse_Recursive_Impl(lst).head;
        }

        public static (ListNode<T> head, ListNode<T> tail) Reverse_Recursive_Impl<T>(ListNode<T> node)
        {
            if (node?.Next == null) return (node, node);

            var nextReversed = Reverse_Recursive_Impl(node.Next);
            nextReversed.tail.Next = node;
            node.Next = null;

            return (nextReversed.head, node);
        }

        public static ListNode<T> Reverse_Iterative<T>(ListNode<T> node)
        {
            ListNode<T> head = null;
            while (node != null)
            {
                var next = node.Next;
                node.Next = head;
                head = node;
                node = next;
            }

            return head;
        }
    }
}
