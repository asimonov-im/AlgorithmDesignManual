namespace AlgorithmDesignTests.Exercises.Chapter5
{
    using System;
    using AlgorithmDesign.DataStructures;
    using AlgorithmDesign.Exercises.Chapter5;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ExpressionTreeTests
    {
        [TestMethod]
        public void ExpressionInEvaluatedCorrectly()
        {
            // 2 + 3 ∗ 4 + (3 ∗ 4) / 5
            var expression = new BinaryTreeNode<string>("+")
            {
                Left = new BinaryTreeNode<string>("/")
                {
                    Left = new BinaryTreeNode<string>("*")
                    {
                        Left = new BinaryTreeNode<string>("3"),
                        Right = new BinaryTreeNode<string>("4")
                    },
                    Right = new BinaryTreeNode<string>("5")
                },
                Right = new BinaryTreeNode<string>("+")
                {
                    Left = new BinaryTreeNode<string>("2"),
                    Right = new BinaryTreeNode<string>("*")
                    {
                        Left = new BinaryTreeNode<string>("3"),
                        Right = new BinaryTreeNode<string>("4")
                    }
                }
            };

            Assert.AreEqual(16, ExpressionTree.Evaluate(expression));
        }
    }
}
