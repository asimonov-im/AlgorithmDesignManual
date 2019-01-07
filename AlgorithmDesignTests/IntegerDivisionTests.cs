namespace AlgorithmDesignTests
{
    using System;
    using System.Collections.Generic;
    using AlgorithmDesign.Algorithms;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IntegerDivisionTests
    {
        private static List<(int, int)> TestCases = new List<(int, int)>()
        {
            (0, 3),
            (5, 11),
            (11, 5),
            (238, 14),
            (3780, 53)
        };

        [TestMethod]
        public void Naive()
        {
            TestImpl(IntegerDivision.Naive);
        }

        [TestMethod]
        public void PowersOfTwoDecomposition()
        {
            TestImpl(IntegerDivision.PowersOfTwoDecomposition);
        }

        private static void TestImpl(Func<int, int, int> impl)
        {
            foreach (var testCase in TestCases)
            {
                int expectedResult = testCase.Item1 / testCase.Item2;
                int actualResult = impl(testCase.Item1, testCase.Item2);

                Assert.AreEqual(expectedResult, actualResult);
            }
        }
    }
}
