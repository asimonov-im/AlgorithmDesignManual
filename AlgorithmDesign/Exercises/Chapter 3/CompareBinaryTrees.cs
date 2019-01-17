namespace AlgorithmDesignTests.Exercises.Chapter3
{
    using System;
    using System.Collections.Generic;
    using AlgorithmDesign.DataStructures;

    public static class CompareBinaryTrees
    {
        public static bool AreIdentical<T>(BinaryTreeNode<T> rootA, BinaryTreeNode<T> rootB)
            where T : IComparable<T>
        {
            if (rootA == null || rootB == null)
            {
                return ReferenceEquals(rootA, rootB);
            }

            return rootA.Data.Equals(rootB.Data) &&
                   AreIdentical(rootA.Left, rootB.Left) &&
                   AreIdentical(rootA.Right, rootB.Right);
        }

        public static bool AreIdentical2<T>(BinaryTreeNode<T> rootA, BinaryTreeNode<T> rootB)
            where T : IComparable<T>
        {
            var aStack = new Stack<BinaryTreeNode<T>>();
            var bStack = new Stack<BinaryTreeNode<T>>();

            aStack.Push(rootA);
            bStack.Push(rootB);

            while (aStack.Count > 0 && bStack.Count > 0)
            {
                var aNode = aStack.Pop();
                var bNode = bStack.Pop();

                if (aNode != null && bNode != null)
                {
                    if (!aNode.Data.Equals(bNode.Data)) return false;

                    aStack.Push(aNode.Left);
                    aStack.Push(aNode.Right);
                    bStack.Push(bNode.Left);
                    bStack.Push(bNode.Right);
                }
                else if (aNode == null ^ bNode == null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
