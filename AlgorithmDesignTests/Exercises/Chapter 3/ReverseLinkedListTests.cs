namespace AlgorithmDesignTests.Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AlgorithmDesign.DataStructures;
    using AlgorithmDesign.Exercises.Chapter3;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ReverseLinkedListTests
    {
        private static readonly List<int[]> TestCases = new List<int[]>
            {
                new int[] { },
                new int[] { 1 },
                new int[] { 1, 2, 3, 4, 5}
            };

        [TestMethod]
        public void Reverse_Recursive()
        {
            CheckReverseImpl(ReverseLinkedList.Reverse_Iterative);
        }

        [TestMethod]
        public void Reverse_Iterative()
        {
            CheckReverseImpl(ReverseLinkedList.Reverse_Iterative);
        }

        private static void CheckReverseImpl(Func<ListNode<int>, ListNode<int>> reverse)
        {
            foreach (var testCase in TestCases)
            {
                var input = ListNode<int>.CreateList(testCase);
                var expectedOutput = testCase.Reverse().ToList();
                var actualOutput = ListNode<int>.AsEnumerable(reverse(input)).ToList();

                CollectionAssert.AreEqual(expectedOutput, actualOutput);
            }
        }
    }
}
