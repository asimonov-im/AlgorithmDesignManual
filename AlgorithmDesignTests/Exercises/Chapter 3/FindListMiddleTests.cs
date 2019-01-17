namespace AlgorithmDesignTests.Exercises
{
    using System.Linq;
    using AlgorithmDesign.DataStructures;
    using AlgorithmDesign.Exercises.Chapter3;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FindListMiddleTests
    {
        private static readonly ListNode<int> OddList =
            ListNode<int>.CreateList(new int[] { 1, 2, 3, 4, 5 });

        private static readonly ListNode<int> EvenList =
            ListNode<int>.CreateList(new int[] { 1, 2, 3, 4, 5, 6 });

        [TestMethod]
        public void CanFindMiddleOfEmptyList()
        {
            var middleNode = FindListMiddle.FindMiddle<int>(null);
            Assert.IsNull(middleNode);
        }

        [TestMethod]
        public void CanFindMiddleOfOddList()
        {
            var middleNode = FindListMiddle.FindMiddle(OddList);
            Assert.AreEqual(3, middleNode.Value);
        }

        [TestMethod]
        public void CanFindMiddleOfEvenList()
        {
            var middleNode = FindListMiddle.FindMiddle(EvenList);
            Assert.AreEqual(3, middleNode.Value);
        }
    }
}
