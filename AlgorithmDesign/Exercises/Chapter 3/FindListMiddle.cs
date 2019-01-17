namespace AlgorithmDesign.Exercises.Chapter3
{
    using AlgorithmDesign.DataStructures;

    public static class FindListMiddle
    {
        public static ListNode<T> FindMiddle<T>(ListNode<T> head)
        {
            if (head == null) return head;

            var slowRunner = head;
            var fastRunner = head;

            while (fastRunner.Next?.Next != null)
            {
                slowRunner = slowRunner.Next;
                fastRunner = fastRunner.Next.Next;
            }

            return slowRunner;
        }
    }
}
