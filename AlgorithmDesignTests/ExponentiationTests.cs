namespace AlgorithmDesignTests
{
    using System;
    using System.Collections.Generic;
    using AlgorithmDesign.Algorithms;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ExponentiationTests
    {
        private static readonly List<(uint, uint)> TestCases = new List<(uint, uint)>()
        {
            (3, 0),
            (3, 1),
            (2, 5),
            (7, 13)
        };

        [TestMethod]
        public void DivideAndConquer()
        {
            foreach (var testCase in TestCases)
            {
                uint expectedResult = (uint)Math.Pow(testCase.Item1, testCase.Item2);
                uint actualResult = Exponentiation.DivideAndConquer(testCase.Item1, testCase.Item2);

                Assert.AreEqual(expectedResult, actualResult);
            }
            
        }
    }
}
