namespace AlgorithmDesign.Exercises.Chapter5
{
    using System.Collections.Generic;
    using AlgorithmDesign.DataStructures;

    public static class ReconstructTree
    {
        public static BinaryTreeNode<T> Reconstruct<T>(IReadOnlyList<T> preOrder, IReadOnlyList<T> inOrder)
        {
            BinaryTreeNode<T> result = null;

            if (preOrder.Count > 0)
            {
                T root = preOrder[0];

                // Find index of the root in the in-order traversal
                int rootIndex = IndexOf(inOrder, root);

                BinaryTreeNode<T> leftSubtree = null;
                int rightMostInLeft = rootIndex;
                if (rootIndex > 0)
                {
                    // Find the index of the right-most node of the left subtree, in the pre-order traversal
                    rightMostInLeft = IndexOf(preOrder, inOrder[rootIndex - 1]);

                    leftSubtree = Reconstruct(
                        new ReadOnlySubList<T>(preOrder, 1, rightMostInLeft),
                        new ReadOnlySubList<T>(inOrder, 0, rootIndex - 1));
                }

                BinaryTreeNode<T> rightSubtree = null;
                if (rootIndex < inOrder.Count - 1)
                {
                    rightSubtree = Reconstruct(
                        new ReadOnlySubList<T>(preOrder, rightMostInLeft + 1, preOrder.Count - 1),
                        new ReadOnlySubList<T>(inOrder, rootIndex + 1, inOrder.Count - 1));
                }

                result = new BinaryTreeNode<T>(root, leftSubtree, rightSubtree);
            }

            return result;
        }

        private static int IndexOf<T>(IReadOnlyList<T> list, T value)
        {
            for (int i = 0; i < list.Count; ++i)
            {
                if (list[i].Equals(value)) return i;
            }

            return -1;
        }
    }
}
