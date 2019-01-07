namespace AlgorithmDesign
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AlgorithmDesign.DataStructures;

    public static partial class TravellingSalesman
    {
        public static List<Point2D> ClosestPair(IReadOnlyCollection<Point2D> input)
        {
            var vertexChains = new HashSet<Chain>();
            foreach (var p in input)
            {
                vertexChains.Add(new Chain(p));
            }

            for (int i = 1; i < input.Count; ++i)
            {
                double minDistance = double.PositiveInfinity;
                var joinCandidates = new ChainEndpoint[2];
                foreach (var c1 in vertexChains)
                {
                    foreach (var c2 in vertexChains)
                    {
                        if (ReferenceEquals(c1, c2)) continue;

                        CheckCandidates(c1.First, c2.First, ref minDistance, joinCandidates);
                        CheckCandidates(c1.Last, c2.First, ref minDistance, joinCandidates);
                        CheckCandidates(c1.First, c2.Last, ref minDistance, joinCandidates);
                        CheckCandidates(c1.Last, c2.Last, ref minDistance, joinCandidates);
                    }
                }

                var joined = Join(joinCandidates[0], joinCandidates[1]);
                vertexChains.Remove(joinCandidates[0].Parent);
                vertexChains.Remove(joinCandidates[1].Parent);
                vertexChains.Add(joined);
            }

            return vertexChains.FirstOrDefault()?.Points ?? new List<Point2D>();
        }

        private static Chain Join(ChainEndpoint a, ChainEndpoint b)
        {
            if (a.IsFirst)
            {
                if (b.IsFirst)
                {
                    if (a.Parent.Points.Count < b.Parent.Points.Count)
                    {
                        return Join(a.Parent.Reverse(), b.Parent);
                    }
                    else
                    {
                        return Join(b.Parent.Reverse(), a.Parent);
                    }
                }
                else
                {
                    return Join(b.Parent, a.Parent);
                }
            }
            else
            {
                return Join(b, a);
            }
        }

        private static Chain Join(Chain a, Chain b)
        {
            a.Append(b);
            return a;
        }

        private static void CheckCandidates(ChainEndpoint v1, ChainEndpoint v2, ref double minDistance, ChainEndpoint[] candidates)
        {
            double distance = Point2D.Distance(v1.Point, v2.Point);
            if (distance < minDistance)
            {
                candidates[0] = v1;
                candidates[1] = v2;
                minDistance = distance;
            }
        }

        private class Chain
        {
            public ChainEndpoint First => new ChainEndpoint(Points.First(), this);
            public ChainEndpoint Last => new ChainEndpoint(Points.Last(), this);

            public List<Point2D> Points { get; private set; }

            public Chain(Point2D point)
            {
                Points = new List<Point2D>();
                Points.Add(point);
            }

            private Chain(List<Point2D> points)
            {
                Points = points;
            }

            public void Append(Chain c)
            {
                Points.AddRange(c.Points);
            }

            public Chain Reverse()
            {
                var pointsCopy = Points.ToList();
                pointsCopy.Reverse();

                return new Chain(pointsCopy);
            }
        }

        private class ChainEndpoint
        {
            public Chain Parent { get; private set; }

            public Point2D Point { get; private set; }

            public bool IsFirst => Parent.Points.First() == Point;
            public bool IsLast => Parent.Points.Last() == Point;

            public ChainEndpoint(Point2D point, Chain parent)
            {
                Parent = parent ?? throw new ArgumentNullException(nameof(parent));
                Point = point;
            }
        }
    }
}
