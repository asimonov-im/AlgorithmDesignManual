namespace AlgorithmDesignTests.Exercises.Chapter4
{
    using System;
    using AlgorithmDesign.Exercises.Chapter4;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FirstMissingIntTests
    {
        [TestMethod]
        public void MissingIntIsFound()
        {
            var input1 = new int[0];
            Assert.AreEqual(1, FirstMissingInt.Find(input1));

            var input2 = new int[] { 1, 2, 3 };
            Assert.AreEqual(4, FirstMissingInt.Find(input2));

            var input3 = new int[] { 2, 3, 4 };
            Assert.AreEqual(1, FirstMissingInt.Find(input3));

            var input4 = new int[] { 1, 2, 4, 5, 7 };
            Assert.AreEqual(3, FirstMissingInt.Find(input4));
        }
    }
}
