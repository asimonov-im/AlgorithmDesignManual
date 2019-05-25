namespace AlgorithmDesignTests.Exercises.Chapter8
{
    using System;
    using System.Collections.Generic;
    using AlgorithmDesign.Exercises.Chapter8;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using static AlgorithmDesign.Exercises.Chapter8.EditDistanceWithSwap;

    [TestClass]
    public class EditDistanceTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var actual = EditDistanceWithSwap.Get("you should not", "thou shall not");
            var expected = new List<EditType>
            {
                 EditType.Delete,
                 EditType.Replace,
                 EditType.Match,
                 EditType.Match,
                 EditType.Match,
                 EditType.Match,
                 EditType.Match,
                 EditType.Insert,
                 EditType.Replace,
                 EditType.Match,
                 EditType.Replace,
                 EditType.Match,
                 EditType.Match,
                 EditType.Match,
                 EditType.Match,
            };

            CollectionAssert.AreEquivalent(actual, expected);
        }
    }
}
