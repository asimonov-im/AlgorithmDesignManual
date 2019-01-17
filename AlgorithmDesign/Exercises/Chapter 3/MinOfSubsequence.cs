namespace AlgorithmDesign.Exercises.Chapter3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AlgorithmDesign.Data_Structures;

    public class MinOfSubsequence
    {
        private MinNode Root { get; }

        private MinOfSubsequence(MinNode root)
        {
            Root = root;
        }

        public static MinOfSubsequence Create(IReadOnlyList<int> values)
        {
            var nodes = new List<MinNode>(values.Count);
            var leafNodes = values.Select((val, idx) => new MinNode(val, new Interval<int>(idx, idx)));
            nodes.InsertRange(0, leafNodes);

            int nodeCount = nodes.Count;
            while (nodeCount > 1)
            {
                int mergedNodeIndex = 0;
                int numPairs = nodeCount / 2;
                for (int i = 0; i < numPairs; ++i)
                {
                    nodes[mergedNodeIndex++] = MergeNodes(nodes[2 * i], nodes[2 * i + 1]);
                }

                // Account for case of unpaired last node
                if (nodeCount % 2 == 1)
                {
                    nodes[mergedNodeIndex++] = nodes[nodeCount - 1];
                }

                nodeCount = mergedNodeIndex;
            }

            return new MinOfSubsequence(nodes.First());
        }

        public int FindMin(int i, int j)
        {
            return FindMin(new Interval<int>(i, j), Root);
        }

        private int FindMin(Interval<int> interval, MinNode node)
        {
            if (node.Interval == interval)
            {
                return node.MinValue;
            }
            else if (node.Left.Interval.Contains(interval))
            {
                return FindMin(interval, node.Left);
            }
            else if (node.Right.Interval.Contains(interval))
            {
                return FindMin(interval, node.Right);
            }
            else
            {
                int leftMin = FindMin(new Interval<int>(interval.Start, node.Left.Interval.End), node.Left);
                int rightMin = FindMin(new Interval<int>(node.Right.Interval.Start, interval.End), node.Right);

                return Math.Min(leftMin, rightMin);
            }
        }

        private static MinNode MergeNodes(MinNode left, MinNode right)
        {
            var mergedInterval = new Interval<int>(
                left.Interval.Start,
                right.Interval.End
            );
            var mergedMinimum = Math.Min(
                left.MinValue,
                right.MinValue
            );

            return new MinNode(mergedMinimum, mergedInterval, left, right);
        }

        private class MinNode
        {
            public int MinValue { get; }

            public Interval<int> Interval { get; }

            public MinNode Left { get; }

            public MinNode Right { get; }

            public MinNode(
                int minValue,
                Interval<int> interval,
                MinNode left = null,
                MinNode right = null)
            {
                MinValue = minValue;
                Interval = interval;
                Left = left;
                Right = right;
            }
        }
    }
}
