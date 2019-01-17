namespace AlgorithmDesign.Exercises.Chapter3
{
    using System;
    using AlgorithmDesign.Algorithms;
    using AlgorithmDesign.DataStructures;

    public static class BSTToLinkedList
    {
        public static ListNode<T> Convert_Recursive<T>(BinaryTreeNode<T> root)
        {
            return ConvertImpl(root).head;
        }

        public static ListNode<T> Convert_InOrderTraversal<T>(BinaryTreeNode<T> root)
            where T : IComparable<T>
        {
            ListNode<T> head = null;
            ListNode<T> tail = null;

            foreach (T value in TreeTraversal.InOrder_NoParent(root))
            {
                var node = new ListNode<T>(value);
                if (tail != null)
                {
                    tail.Next = node;
                    tail = node;
                }
                else
                {
                    head = tail = node;
                }
            }

            return head;
        }

        public static ListNode<T> Convert_Rotations<T>(BinaryTreeNode<T> root)
        {
            if (root == null) return null;

            // Do a left rotation on the root, until it has no right children
            while (root.Right != null)
            {
                root = TreeTraversal.RotateLeft(root);
            }

            // Go down the left subtree, performing left rotations until
            // each node has no more right children
            var node = root;
            while (node.Left != null)
            {
                while (node.Right != null)
                {
                    node = TreeTraversal.RotateLeft(node);
                }
                node = node.Left;
            }

            // The tree should now be degenerate, with the largest
            // value being the root and each node only having a left child
            ListNode<T> head = null;
            while (root != null)
            {
                head = new ListNode<T>(root.Data)
                {
                    Next = head
                };
                root = root.Left;
            }

            return head;
        }

        private static (ListNode<T> head, ListNode<T> tail) ConvertImpl<T>(BinaryTreeNode<T> treeNode)
        {
            if (treeNode == null) return (null, null);

            var node = new ListNode<T>(treeNode.Data);
            var leftResult = ConvertImpl(treeNode.Left);
            var rightResult = ConvertImpl(treeNode.Right);

            ListNode<T> head = node;
            if (leftResult.tail != null)
            {
                head = leftResult.head;
                leftResult.tail.Next = node;
            }

            ListNode<T> tail = node;
            if (rightResult.head != null)
            {
                tail = rightResult.tail;
                node.Next = rightResult.head;
            }

            return (head, tail);
        }
    }
}
