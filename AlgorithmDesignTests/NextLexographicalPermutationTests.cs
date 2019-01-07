namespace AlgorithmDesignTests
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AlgorithmDesign.Algorithms.NextLexographicalPermutation;

    [TestClass]
    public class NextLexographicalPermutationTests
    {
        [TestMethod]
        public void EmptySequenceHasNoNextPermutation()
        {
            var emptySeq = new List<int>();

            bool result = emptySeq.NextPermutation();

            Assert.IsFalse(result);
            Assert.AreEqual(0, emptySeq.Count);
        }

        [TestMethod]
        public void SequenceWithSingleValueHasNoNextPermutation()
        {
            var seq = new List<int> { 'a' };

            bool result = seq.NextPermutation();

            Assert.IsFalse(result);
            Assert.AreEqual(1, seq.Count);
            Assert.AreEqual('a', seq.First());
        }

        [TestMethod]
        public void PermutationsAreComputedCorrectly()
        {
            List<string> permutations = new List<string>
            {
                "1375",
                "1537",
                "1573",
                "1735",
                "1753",
                "3157",
                "3175",
                "3517",
                "3571",
                "3715",
                "3751",
                "5137",
                "5173",
                "5317",
                "5371",
                "5713",
                "5731",
                "7135",
                "7153",
                "7315",
                "7351",
                "7513",
                "7531",
            };

            var seq = MakeSequence("1357");
            foreach (var p in permutations)
            {
                bool result = seq.NextPermutation();

                Assert.IsTrue(result);
                CollectionAssert.AreEqual(seq, MakeSequence(p));
            }
        }

        private List<int> MakeSequence(string digitSequence)
        {
            return digitSequence.Select(d => d - '0').ToList();
        }
    }
}
