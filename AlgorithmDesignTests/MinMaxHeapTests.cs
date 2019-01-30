namespace AlgorithmDesignTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AlgorithmDesign.DataStructures;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MinMaxHeapTests
    {
        private static readonly List<int> Values =
            Utils.RandomSequence(1, 10000).Take(1000000).ToList();

        private static readonly List<int> SortedValues
            = Values.OrderBy(s => s).ToList();

        [TestMethod]
        public void HeapIsConstructedCorrectlyFromEnumerable()
        {
            var heap = new MinMaxHeap<int>(Values);
            var heapCopy = heap.ShallowCopy();

            CheckMinValues(heap, SortedValues);
            CheckMaxValues(heapCopy, SortedValues);
        }

        [TestMethod]
        public void HeapIsConstructedCorrectlyViaInsertions()
        {
            var heap = new MinMaxHeap<int>(Values.Count);
            foreach (int value in Values)
            {
                heap.Insert(value);
            }

            var heapCopy = heap.ShallowCopy();

            CheckMinValues(heap, SortedValues);
            CheckMaxValues(heapCopy, SortedValues);
        }

        private void CheckMinValues(MinMaxHeap<int> heap, List<int> ascendingValues)
        {
            foreach (int expectedMin in ascendingValues)
            {
                int actualMin = heap.ExtractMin();
                Assert.AreEqual(expectedMin, actualMin);
            }
        }

        private void CheckMaxValues(MinMaxHeap<int> heap, List<int> ascendingValues)
        {
            var descendingValues = ascendingValues.AsEnumerable().Reverse();
            foreach (int expectedMax in descendingValues)
            {
                int actualMax = heap.ExtractMax();
                Assert.AreEqual(expectedMax, actualMax);
            }
        }
    }
}
