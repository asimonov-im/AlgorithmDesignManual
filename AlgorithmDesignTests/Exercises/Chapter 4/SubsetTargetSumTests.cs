namespace AlgorithmDesignTests.Exercises.Chapter4
{
    using System.Collections.Generic;
    using System.Linq;
    using AlgorithmDesign.Exercises.Chapter4;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SubsetTargetSumTests
    {
        private static List<int> TestValues = new List<int>()
        {
            1, 2, 3, 5, 7, 9, 10, 11, 13
        };

        [TestMethod]
        public void Sum2Tests()
        {
            var result1 = SubsetTargetSum.Sum2(TestValues, 30);
            Assert.AreEqual(0, result1.Count());

            var result2 = SubsetTargetSum.Sum2(TestValues, 12);
            Assert.AreEqual(4, result2.Count());
        }

        [TestMethod]
        public void Sum3Tests()
        {
            var result1 = SubsetTargetSum.Sum3(TestValues, 5);
            Assert.AreEqual(0, result1.Count());

            var result2 = SubsetTargetSum.Sum3(TestValues, 16);
            Assert.AreEqual(4, result2.Count());
        }

        [TestMethod]
        public void SumKTests()
        {
            var result1 = SubsetTargetSum.SumK(TestValues, 5, 4);
            Assert.IsFalse(result1);

            var result2 = SubsetTargetSum.SumK(TestValues, 20, 4);
            Assert.IsTrue(result2);
        }
    }
}
