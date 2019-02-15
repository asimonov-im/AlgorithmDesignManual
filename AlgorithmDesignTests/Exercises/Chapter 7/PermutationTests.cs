namespace AlgorithmDesignTests.Exercises.Chapter7
{
    using System.Collections.Generic;
    using AlgorithmDesign.Algorithms;
    using AlgorithmDesign.Exercises.Chapter7;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PermutationTests
    {
        private static List<char> Items = new List<char> { 'a', 'b', 'c', 'd' };

        [TestMethod]
        public void AllPermutationsAreGenerated()
        {
            var generator = new Permutations<char>(Items);
            var items = new List<char>(Items);

            foreach (var p in generator.Get())
            {
                CollectionAssert.AreEquivalent(items, p);
                NextLexographicalPermutation.NextPermutation(items);
            }
        }
    }
}
