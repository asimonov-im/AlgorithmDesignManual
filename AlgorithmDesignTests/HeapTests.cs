namespace AlgorithmDesignTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AlgorithmDesign.DataStructures;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HeapTests
    {
        private static readonly List<int> Values
            = Utils.RandomSequence(1, 100).Take(30).ToList();

        private static readonly List<int> SortedValues
            = Values.OrderBy(s => s).ToList();

        [TestMethod]
        public void HeapIsConstructedCorrectlyFromEnumerable()
        {
            var heap = new Heap<int>(Values);

            CheckHeapValues(heap, SortedValues);
        }

        [TestMethod]
        public void HeapIsConstructedCorrectlyViaInsertions()
        {
            var heap = new Heap<int>(Values.Count);
            foreach (int value in Values) heap.Insert(value);

            CheckHeapValues(heap, SortedValues);
        }

        private void CheckHeapValues(Heap<int> heap, List<int> sortedValues)
        {
            foreach (int expectedMin in sortedValues)
            {
                int actualMin = heap.ExtractMin();
                Assert.AreEqual(expectedMin, actualMin);
            }
        }
    }
}
