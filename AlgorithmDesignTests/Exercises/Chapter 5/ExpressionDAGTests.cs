namespace AlgorithmDesignTests.Exercises.Chapter5
{
    using System;
    using AlgorithmDesign.DataStructures;
    using AlgorithmDesign.Exercises.Chapter5;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ExpressionDAGTests
    {
        [TestMethod]
        public void ExpressionInEvaluatedCorrectly()
        {
            var graph = new Graph<string>();

            var mult = new GraphNode<string>("*");
            graph.AddDirectedEdge(mult, new GraphNode<string>("3"));
            graph.AddDirectedEdge(mult, new GraphNode<string>("4"));

            var add = new GraphNode<string>("+");
            graph.AddDirectedEdge(add, new GraphNode<string>("2"));
            graph.AddDirectedEdge(add, mult);

            var div = new GraphNode<string>("/");
            graph.AddDirectedEdge(div, mult);
            graph.AddDirectedEdge(div, new GraphNode<string>("5"));

            var root = new GraphNode<string>("+");
            graph.AddDirectedEdge(root, add);
            graph.AddDirectedEdge(root, div);

            Assert.AreEqual(16, ExpressionDAG.Evaluate(root));
        }
    }
}
