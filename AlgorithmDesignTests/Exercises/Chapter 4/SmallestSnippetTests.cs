namespace AlgorithmDesignTests.Exercises.Chapter4
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using static AlgorithmDesign.Exercises.Chapter4.SmallestSnippet;

    [TestClass]
    public class SmallestSnippetTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var occurences = new List<WordOccurances>
            {
                new WordOccurances("word1")
                {
                    Positions = { 1, 4, 11, 27 }
                },
                new WordOccurances("word2")
                {
                    Positions = { 3, 6, 10, 19 }
                },
                new WordOccurances("word3")
                {
                    Positions = { 5, 8, 12, 14 }
                },
            };

            Assert.AreEqual((3, 5), FindMinSpan(occurences));
        }
    }
}
