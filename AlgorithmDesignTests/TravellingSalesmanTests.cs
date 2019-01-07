namespace AlgorithmDesignTests
{
    using System.Collections.Generic;
    using System.Linq;
    using AlgorithmDesign;
    using AlgorithmDesign.DataStructures;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TravellingSalesmanTests
    {
        private static List<Point2D> input1 = new List<Point2D>
        {
            new Point2D(0.0f, 0.0f),
            new Point2D(1.0f, 0.0f),
            new Point2D(-1.0f, 0.0f),
            new Point2D(3.0f, 0.0f),
            new Point2D(-5.0f, 0.0f),
            new Point2D(11.0f, 0.0f),
            new Point2D(-21.0f, 0.0f),
        };

        const float delta = 0.01f;
        const float a = 1.0f - delta;
        const float b = 1.0f + delta;
        private static List<Point2D> input2 = new List<Point2D>
        {
            new Point2D(0.0f, 0.0f),
            new Point2D(0.0f, a),
            new Point2D(b, 0.0f),
            new Point2D(b, a),
            new Point2D(2 * b, 0.0f),
            new Point2D(2 * b, a),
        };

        [TestMethod]
        public void NearestNeighbor()
        {
            var output = TravellingSalesman.NearestNeighbor(input1);
        }

        [TestMethod]
        public void ClosestPair()
        {
            var output = TravellingSalesman.ClosestPair(input2);
        }

        [TestMethod]
        public void Optimal()
        {
            var output1 = TravellingSalesman.Optimal(input1);
            var output2 = TravellingSalesman.Optimal(input2);
        }
    }
}
