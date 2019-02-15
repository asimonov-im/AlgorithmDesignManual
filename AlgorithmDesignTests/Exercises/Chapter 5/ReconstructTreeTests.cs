namespace AlgorithmDesignTests.Exercises.Chapter5
{
    using System;
    using System.Collections.Generic;
    using AlgorithmDesign.Exercises.Chapter5;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ReconstructTreeTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var preOrder = new List<char>()
            {
                'A', 'B', 'D', 'E', 'C', 'F', 'G', 'H'
            };
            var inOrder = new List<char>()
            {
                'D', 'B', 'E', 'A', 'C', 'G', 'F', 'H'
            };

            var tree = ReconstructTree.Reconstruct(preOrder, inOrder);
        }
    }
}
