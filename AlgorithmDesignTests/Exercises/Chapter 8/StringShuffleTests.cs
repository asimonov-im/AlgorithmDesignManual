namespace AlgorithmDesignTests.Exercises.Chapter8
{
    using AlgorithmDesign.Exercises.Chapter8;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StringShuffleTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(StringShuffle.Check("chocolate", "chips", "cchocohilaptes"));
            Assert.IsFalse(StringShuffle.Check("chocolate", "chips", "chocochilatspe"));
        }
    }
}
