namespace AlgorithmDesignTests.Exercises.Chapter_7
{
    using System.Collections.Generic;
    using AlgorithmDesign.Exercises.Chapter7;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DerangementTests
    {
        [TestMethod]
        public void AllDerangementsAreGenerated()
        {
            var items = new List<int> { 1, 2, 3, 4 };
            var derangements = new List<List<int>>
            {
                new List<int> { 2, 1, 4, 3},
                new List<int> { 2, 3, 4, 1},
                new List<int> { 2, 4, 1, 3},
                new List<int> { 3, 1, 4, 2},
                new List<int> { 3, 4, 1, 2},
                new List<int> { 3, 4, 2, 1},
                new List<int> { 4, 1, 2, 3},
                new List<int> { 4, 3, 1, 2},
                new List<int> { 4, 3, 2, 1},
            };

            int i = 0;
            var generator = new Derangements<int>(items);
            foreach (var d in generator.Get())
            {
                CollectionAssert.AreEquivalent(derangements[i++], d);
            }
        }
    }
}
