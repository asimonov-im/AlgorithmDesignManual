namespace AlgorithmDesignTests.Exercises.Chapter_4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AlgorithmDesign.Exercises.Chapter4;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class OneZeroSortTests
    {
        private static readonly List<int> Values
            = Utils.RandomSequence(0, 2).Take(30).ToList();

        [TestMethod]
        public void TestMethod1()
        {
            OneZeroSort.Sort_V1(Values);
        }
    }
}
