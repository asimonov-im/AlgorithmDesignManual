namespace AlgorithmDesignTests.Exercises.Chapter4
{
    using System;
    using AlgorithmDesign.Exercises.Chapter4;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IntWithMatchingIndexTests
    {
        private static readonly int[] TestValues1 = new int[] { -10, -3, 2, 5, 7 };
        private static readonly int[] TestValues2 = new int[] { 2, 3, 4, 5, 6, 7 };

        [TestMethod]
        public void TestMethod1()
        {
            var actual1 = IntWithMatchingIndex.Find(TestValues1);
            var actual2 = IntWithMatchingIndex.Find(TestValues2);

            Assert.AreEqual(2, actual1);
            Assert.AreEqual(-1, actual2);
        }
    }
}
