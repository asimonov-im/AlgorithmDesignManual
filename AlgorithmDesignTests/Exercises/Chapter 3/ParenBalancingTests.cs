namespace AlgorithmDesignTests.Exercises
{
    using AlgorithmDesign.Exercises.Chapter3;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ParenBalancingTests
    {
        [TestMethod]
        public void EmptyStringIsBalanced()
        {
            var result = ParenBalancing.CheckBalance(string.Empty);

            Assert.IsTrue(result.isBalanced);
        }

        [TestMethod]
        public void SingleOpenParenIsUnbalanced()
        {
            var result = ParenBalancing.CheckBalance("(");

            Assert.IsFalse(result.isBalanced);
            Assert.AreEqual(0, result.errorIndex);
        }

        [TestMethod]
        public void SingleClosingParenIsUnbalanced()
        {
            var result = ParenBalancing.CheckBalance(")");

            Assert.IsFalse(result.isBalanced);
            Assert.AreEqual(0, result.errorIndex);
        }

        [TestMethod]
        public void ParensAreBalanced()
        {
            var result = ParenBalancing.CheckBalance("((())())()");

            Assert.IsTrue(result.isBalanced);
        }

        [TestMethod]
        public void ParensAreUnbalanced()
        {
            var result = ParenBalancing.CheckBalance("()(()");

            Assert.IsFalse(result.isBalanced);
            Assert.AreEqual(2, result.errorIndex);
        }
    }
}
