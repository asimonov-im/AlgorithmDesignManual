namespace AlgorithmDesign.DataStructures
{
    using System;
    using System.Collections.Generic;

    public class BinaryTreeNode<T>
    {
        BinaryTreeNode<T> leftChild;
        BinaryTreeNode<T> rightChild;

        public T Data { get; private set; }

        public BinaryTreeNode<T> Left
        {
            get => leftChild;

            set
            {
                if (value != null) value.Parent = this;
                if (leftChild != null) leftChild.Parent = null;
                leftChild = value;
            }
        }

        public BinaryTreeNode<T> Right
        {
            get => rightChild;

            set
            {
                if (value != null) value.Parent = this;
                if (rightChild != null) rightChild.Parent = null;
                rightChild = value;
            }
        }

        public BinaryTreeNode<T> Parent { get; set; }

        public BinaryTreeNode(T data)
        {
            Data = data;
        }

        public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            Data = data;
            Left = left;
            Right = right;
        }

        public static BinaryTreeNode<T> MakeBinarySearchTree(List<T> values)
        {
            values.Sort();

            return MakeBinarySearchTree(values, 0, values.Count - 1);
        }

        private static BinaryTreeNode<T> MakeBinarySearchTree(IReadOnlyList<T> values, int i, int j)
        {
            if (i > j) return null;

            int mid = i + (j - i) / 2;

            return new BinaryTreeNode<T>(values[mid])
            {
                Left = MakeBinarySearchTree(values, i, mid - 1),
                Right = MakeBinarySearchTree(values, mid + 1, j)
            };
        }
    }
}
