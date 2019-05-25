namespace AlgorithmDesignTests.Exercises.Chapter8
{
    using AlgorithmDesign.Exercises.Chapter8;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LongestCommonSubsequenceTests
    {
        [TestMethod]
        public void LCSIsFound()
        {
            Assert.AreEqual(string.Empty, LongestCommonSubsequence.Find(string.Empty, "ABC"));
            Assert.AreEqual(string.Empty, LongestCommonSubsequence.Find("ABC", string.Empty));
            Assert.AreEqual("GTAB", LongestCommonSubsequence.Find("AGGTAB", "GXTXAYB"));
        }
    }
}
