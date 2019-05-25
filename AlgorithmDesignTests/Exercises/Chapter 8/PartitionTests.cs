namespace AlgorithmDesignTests.Exercises.Chapter8
{
    using System;
    using System.Collections.Generic;
    using AlgorithmDesign.Exercises.Chapter8;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PartitionTests
    {
        [TestMethod]
        public void NumberOfPartitionsExceedsNumberOfValues()
        {
            var input = new List<int> { 1, 2, 3, 4 };
            var expected = new List<int> { 0, 1, 2 };

            CollectionAssert.AreEquivalent(expected, new Partition(input, 5).Get());
        }

        [TestMethod]
        public void NumberOfPartitionsEqualsNumberOfValues()
        {
            var input = new List<int> { 1, 2, 3, 4 };
            var expected = new List<int> { 0, 1, 2 };

            CollectionAssert.AreEquivalent(expected, new Partition(input, 4).Get());
        }

        [TestMethod]
        public void ValuesArePartitionedCorrectly()
        {
            var input = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var expected = new List<int> { 4, 6 };

            CollectionAssert.AreEquivalent(expected, new Partition(input, 3).Get());
        }
    }
}
