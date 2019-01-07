namespace AlgorithmDesign
{
    using System.Collections.Generic;
    using System.Linq;
    using AlgorithmDesign.DataStructures;

    public static partial class TravellingSalesman
    {
        public static List<Point2D> NearestNeighbor(IReadOnlyCollection<Point2D> input)
        {
            var points = input.ToList();

            for (int i = 1; i < points.Count; ++i)
            {
                double minDistance = double.PositiveInfinity;
                int minDistanceIndex = -1;
                for (int j = i; j < points.Count; ++j)
                {
                    double distance = Point2D.Distance(points[i - 1], points[j]);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        minDistanceIndex = j;
                    }
                }

                Utils.SwapElements(points, i, minDistanceIndex);
            }

            return points;
        }
    }
}
