namespace AlgorithmDesignTests.Exercises
{
    using System;
    using AlgorithmDesign.Exercises.Chapter3;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ReverseWordsInSentenceTests
    {
        [TestMethod]
        public void WordsAreReversed()
        {
            var input = "My name is Chris";
            var expectedOutput = "Chris is name My";
            var actualOutput = ReverseWordsInSentence.Reverse(input);

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
