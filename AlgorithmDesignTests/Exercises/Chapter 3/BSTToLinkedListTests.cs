namespace AlgorithmDesignTests.Exercises.Chapter_3
{
    using System;
    using System.Collections.Generic;
    using AlgorithmDesign.DataStructures;
    using AlgorithmDesign.Exercises.Chapter3;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BSTToLinkedListTests
    {
        private static readonly List<int> TreeValues = new List<int>()
        {
            1, 3, 5, 7, 9, 11, 13, 15, 17, 19
        };

        private static readonly BinaryTreeNode<int> Tree =
            BinaryTreeNode<int>.MakeBinarySearchTree(TreeValues);

        [TestMethod]
        public void TestMethod1()
        {
            var result = BSTToLinkedList.Convert_Rotations(Tree);
        }
    }
}
