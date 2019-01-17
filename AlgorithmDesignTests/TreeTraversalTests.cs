namespace AlgorithmDesignTests
{
    using System.Collections.Generic;
    using System.Linq;
    using AlgorithmDesign.Algorithms;
    using AlgorithmDesign.DataStructures;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TreeTraversalTests
    {
        private static readonly List<int> TreeValues = new List<int>()
        {
            1, 3, 5, 7, 9, 11, 13, 15, 17, 19
        };

        private static readonly BinaryTreeNode<int> Tree =
            BinaryTreeNode<int>.MakeBinarySearchTree(TreeValues);

        [TestMethod]
        public void InOrder_NoParentTraversalIsCorrect()
        {
            var actualValues = TreeTraversal.InOrder_NoParent(Tree).ToList();
            CollectionAssert.AreEqual(TreeValues, actualValues);
        }

        [TestMethod]
        public void InOrder_WithParentTraversalIsCorrect()
        {
            var actualValues = TreeTraversal.InOrder_WithParent(Tree).ToList();
            CollectionAssert.AreEqual(TreeValues, actualValues);
        }
    }
}
