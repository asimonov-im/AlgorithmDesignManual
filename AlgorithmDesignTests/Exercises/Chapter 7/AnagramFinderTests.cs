namespace AlgorithmDesignTests.Exercises.Chapter7
{
    using System;
    using AlgorithmDesign.DataStructures;
    using AlgorithmDesign.Exercises.Chapter7;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AnagramFinderTests
    {
        private static readonly Trie EnglishWords = Trie.FromWordFile("Exercises\\Chapter 7\\words_alpha.txt");

        [TestMethod]
        public void AnagramsAreFound()
        {
            string input = "astronomers";
            var anagramFinder = new AnagramFinder(input, EnglishWords);
            foreach (var anagram in anagramFinder.Get())
            {
                Assert.IsNotNull(anagram);
            }
        }
    }
}
