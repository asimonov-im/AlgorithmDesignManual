namespace AlgorithmDesign.Algorithms
{
    using System;
    using System.Collections.Generic;
    using AlgorithmDesign.DataStructures;

    public static class TreeTraversal
    {
        public static BinaryTreeNode<T> RotateRight<T>(BinaryTreeNode<T> root)
        {
            var pivot = root.Left ?? throw new InvalidOperationException("Must have left child.");

            UpdateParent(root, pivot);
            root.Left = pivot.Right;
            pivot.Right = root;

            return pivot;
        }

        public static BinaryTreeNode<T> RotateLeft<T>(BinaryTreeNode<T> root)
        {
            var pivot = root.Right ?? throw new InvalidOperationException("Must have right child.");

            UpdateParent(root, pivot);
            root.Right = pivot.Left;
            pivot.Left = root;

            return pivot;
        }

        private static void UpdateParent<T>(BinaryTreeNode<T> oldChild, BinaryTreeNode<T> newChild)
        {
            var grandParent = oldChild?.Parent;
            if (grandParent != null)
            {
                if (grandParent.Left == oldChild)
                {
                    grandParent.Left = newChild;
                }
                else
                {
                    grandParent.Right = newChild;
                }
            }
        }

        public static BinaryTreeNode<T> Successor<T>(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return null;
            }
            else if (node.Right != null)
            {
                node = node.Right;
                while (node.Left != null) node = node.Left;

                return node;
            }
            else
            {
                while (node.Parent != null && node.Parent.Right == node) node = node.Parent;

                return node?.Parent;
            }
        }

        public static BinaryTreeNode<T> Predecessor<T>(BinaryTreeNode<T> node)
        {
            if (node?.Left == null) return null;

            node = node.Left;
            while (node.Right != null) node = node.Right;

            return node;
        }

        public static IEnumerable<T> InOrder_NoParent<T>(BinaryTreeNode<T> root)
        {
            var stack = new Stack<BinaryTreeNode<T>>();

            var current = root;
            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                current = stack.Pop();
                yield return current.Data;

                current = current.Right;
            }
        }

        public static IEnumerable<T> InOrder_WithParent<T>(BinaryTreeNode<T> root)
        {
            BinaryTreeNode<T> current = root;
            BinaryTreeNode<T> previous = root;

            while (current != null)
            {
                if ((current.Left == null && previous == current.Parent) || previous == current.Left)
                {
                    yield return current.Data;
                }

                if (current.Left != null && previous.Parent != current)
                {
                    previous = current;
                    current = current.Left;
                }
                else if (current.Right != null && previous != current.Right)
                {
                    previous = current;
                    current = current.Right;
                }
                else
                {
                    previous = current;
                    current = current.Parent;
                }
            }
        }
    }
}
