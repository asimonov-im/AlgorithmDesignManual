namespace AlgorithmDesignTests.Exercises
{
    using System.Linq;
    using AlgorithmDesign.Exercises.Chapter3;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PartialSumTests
    {
        [TestMethod]
        public void AllSumsAreComputedCorrectly()
        {
            var randomList = Utils.RandomSequence(0, 100).Take(30).ToList();

            var calculator = PartialSum.Create(randomList);

            for (int i = 0; i < randomList.Count; ++i)
            {
                int expectedSum = randomList.Take(i + 1).Sum();
                int actualSum = calculator.GetPartialSum(i);

                Assert.AreEqual(expectedSum, actualSum);
            }

            calculator.Add(10, 42);
            randomList[10] += 42;

            for (int i = 0; i < randomList.Count; ++i)
            {
                int expectedSum = randomList.Take(i + 1).Sum();
                int actualSum = calculator.GetPartialSum(i);

                Assert.AreEqual(expectedSum, actualSum);
            }
        }
    }
}
