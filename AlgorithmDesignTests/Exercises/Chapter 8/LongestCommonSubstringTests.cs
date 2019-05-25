namespace AlgorithmDesignTests.Exercises.Chapter8
{
    using System;
    using AlgorithmDesign.Exercises.Chapter8;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LongestCommonSubstringTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("abcdez", LongestCommonSubstring.Find("zxabcdezy", "yzabcdezx"));
        }
    }
}
