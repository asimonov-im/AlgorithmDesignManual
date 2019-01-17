using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmDesign.Exercises.Chapter3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AlgorithmDesign.Data_Structures;

    public class PartialSum
    {
        private SumNode Root { get; }

        private PartialSum(SumNode root)
        {
            Root = root;
        }

        public static PartialSum Create(IReadOnlyList<int> values)
        {
            var nodes = new List<SumNode>(values.Count);
            var leafNodes = values.Select((val, idx) => new SumNode(val, new Interval<int>(idx, idx)));
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

            return new PartialSum(nodes.First());
        }

        public int GetPartialSum(int i)
        {
            return GetPartialSum(new Interval<int>(0, i), Root);
        }

        public void Add(int i, int y)
        {
            SumNode node = Root;
            Interval<int> interval = new Interval<int>(i, i);

            while (true)
            {
                node.Sum += y;

                if (node.Left?.Interval.Contains(interval) == true)
                {
                    node = node.Left;
                }
                else if (node.Right?.Interval.Contains(interval) == true)
                {
                    node = node.Right;
                }
                else
                {
                    break;
                }
            }
        }

        private int GetPartialSum(Interval<int> interval, SumNode node)
        {
            if (node.Interval == interval)
            {
                return node.Sum;
            }
            else if (node.Left.Interval.Contains(interval))
            {
                return GetPartialSum(interval, node.Left);
            }
            else if (node.Right.Interval.Contains(interval))
            {
                return GetPartialSum(interval, node.Right);
            }
            else
            {
                int leftSum = GetPartialSum(new Interval<int>(interval.Start, node.Left.Interval.End), node.Left);
                int rightSum = GetPartialSum(new Interval<int>(node.Right.Interval.Start, interval.End), node.Right);

                return leftSum + rightSum;
            }
        }

        private static SumNode MergeNodes(SumNode left, SumNode right)
        {
            var mergedInterval = new Interval<int>(
                left.Interval.Start,
                right.Interval.End
            );
            var mergedSum = left.Sum + right.Sum;

            return new SumNode(mergedSum, mergedInterval, left, right);
        }

        private class SumNode
        {
            public int Sum { get; set; }

            public Interval<int> Interval { get; }

            public SumNode Left { get; }

            public SumNode Right { get; }

            public SumNode(
                int sum,
                Interval<int> interval,
                SumNode left = null,
                SumNode right = null)
            {
                Sum = sum;
                Interval = interval;
                Left = left;
                Right = right;
            }
        }
    }
}
