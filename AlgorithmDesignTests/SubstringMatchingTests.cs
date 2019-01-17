namespace AlgorithmDesignTests
{
    using System.Collections.Generic;
    using AlgorithmDesign.Algorithms;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SubstringMatchingTests
    {
        private static readonly List<(string, string)> TestCases = new List<(string, string)>()
        {
            ("abcdef", "cd"),
            ("cd", "abcdef"),
            ("aaaaaaaaaaaaaaaaaaaaaaaaaab", "aaaaaaaaaaaab")

        };

        [TestMethod]
        public void RabinKarp()
        {
            foreach (var testCase in TestCases)
            {
                int expectedResult = testCase.Item1.IndexOf(testCase.Item2);
                int actualResult = SubstringMatching.RabinKarp(testCase.Item1, testCase.Item2);

                Assert.AreEqual(expectedResult, actualResult);
            }
        }
    }
}
