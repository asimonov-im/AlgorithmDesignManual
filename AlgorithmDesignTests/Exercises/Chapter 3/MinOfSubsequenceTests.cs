namespace AlgorithmDesignTests.Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AlgorithmDesign.Exercises.Chapter3;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MinOfSubsequenceTests
    {
        [TestMethod]
        public void AllValuesAreFoundCorrectly()
        {
            var randomList = Utils.RandomSequence(0, 100).Take(30).ToList();

            var minFinder = MinOfSubsequence.Create(randomList);

            for (int i = 0; i < randomList.Count; ++i)
            {
                for (int j = i; j < randomList.Count; ++j)
                {
                    int expectedMin = FindMin(randomList, i, j);
                    int actualMin = minFinder.FindMin(i, j);

                    Assert.AreEqual(expectedMin, actualMin);
                }
            }
        }

        private static int FindMin(IReadOnlyList<int> lst, int startIdx, int endIdx)
        {
            int min = lst[startIdx];
            for (int i = startIdx + 1; i <= endIdx; ++i)
            {
                min = Math.Min(min, lst[i]);
            }

            return min;
        }
    }
}
