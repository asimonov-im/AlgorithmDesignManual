namespace AlgorithmDesignTests.Exercises.Chapter4
{
    using System;
    using System.Collections.Generic;
    using AlgorithmDesign.Exercises.Chapter4;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CircularShiftTests
    {
        [TestMethod]
        public void RightShift_InPlaceIsCorrect()
        {
            var input = new int[] { 1, 2, 3, 4, 5 };
            var expected = new int[] { 3, 4, 5, 1, 2 };

            CircularShift.RightShift_InPlace(input, 3);

            CollectionAssert.AreEqual(expected, input);
        }

        [TestMethod]
        public void RightShiftIsCorrect()
        {
            var input = new int[] { 1, 2, 3, 4, 5 };
            var expected = new int[] { 3, 4, 5, 1, 2 };
            var actual = CircularShift.RightShift(input, 3);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CanComputeRightShift()
        {
            int expectedShift = 4;
            var input = CircularShift.RightShift(new int[] { 1, 2, 3, 4, 5 }, expectedShift);

            var actualShift = CircularShift.FindMinIndex(input);

            Assert.AreEqual(expectedShift, actualShift);
        }
    }
}
