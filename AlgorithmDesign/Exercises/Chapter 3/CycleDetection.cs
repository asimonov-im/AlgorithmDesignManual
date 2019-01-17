namespace AlgorithmDesign.Exercises.Chapter3
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AlgorithmDesign.DataStructures;

    public static class CycleDetection
    {
        public static ListNode<T> FindCycle<T>(ListNode<T> list)
        {
            if (list == null) return null;

            var it2 = list;
            var it1 = list;

            // it2 goes at twice the speed as it1, until the two meet
            // or the faster iterator reaches the end of the list
            while (it2.Next?.Next != null)
            {
                it1 = it1.Next;
                it2 = it2.Next.Next;

                if (it1 == it2) break;
            }

            // check if there was a cycle
            if (it1 != it2) return null;

            it2 = list;
            while (it1 != it2)
            {
                it1 = it1.Next;
                it2 = it2.Next;
            }

            return it2;
        }
    }
}
