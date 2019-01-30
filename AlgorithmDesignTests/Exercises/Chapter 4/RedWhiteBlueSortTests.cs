namespace AlgorithmDesignTests.Exercises.Chapter_4
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using static AlgorithmDesign.Exercises.Chapter4.RedWhiteBlueSort;

    [TestClass]
    public class RedWhiteBlueSortTests
    {
        [TestMethod]
        public void ListIsSorted()
        {
            var input = Utils.RandomSequence(0, 3).Take(30).Select(x => (Color)x).ToList();

            var expected = input.ToList();
            expected.Sort();

            var actual = input.ToList();
            Sort(actual);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
