namespace AlgorithmDesign
{
    using System.Collections.Generic;
    using System.Linq;
    using AlgorithmDesign.Algorithms;
    using AlgorithmDesign.DataStructures;

    public static partial class TravellingSalesman
    {
        private static IComparer<Point2D> PointComparer = Comparer<Point2D>.Create(
            (a, b) =>
            {
                var xCompare = a.X.CompareTo(b.X);
                return xCompare == 0 ? a.Y.CompareTo(b.Y) : xCompare;
            }
        );

        public static List<Point2D> Optimal(IReadOnlyCollection<Point2D> input)
        {
            var points = input.ToList();
            points.Sort(PointComparer);

            double minCost = double.PositiveInfinity;
            List<Point2D> minSolution = null;
            do
            {
                double cost = CycleTourDistance(points);
                if (cost < minCost)
                {
                    minCost = cost;
                    minSolution = points.ToList();
                }
            } while (points.NextPermutation(PointComparer));

            return minSolution;
        }

        public static double CycleTourDistance(IReadOnlyList<Point2D> points)
        {
            double distance = 0.0f;
            for (int i = 1; i < points.Count; ++i)
            {
                distance += Point2D.Distance(points[i - 1], points[i]);
            }

            if (points.Count > 1)
            {
                distance += Point2D.Distance(points.First(), points.Last());
            }

            return distance;
        }
    }
}
