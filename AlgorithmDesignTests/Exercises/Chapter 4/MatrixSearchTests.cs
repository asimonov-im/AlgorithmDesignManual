namespace AlgorithmDesignTests.Exercises.Chapter4
{
    using System;
    using AlgorithmDesign.Exercises.Chapter4;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MatrixSearchTests
    {
        private static readonly int[,] Matrix = {{10, 20, 30, 40, 51},
                                                 {15, 25, 35, 45, 55},
                                                 {27, 29, 37, 48, 58},
                                                 {32, 33, 39, 50, 99}};

        [TestMethod]
        public void DivideAndConquerImplementationWorks()
        {
            TestSearchMethod(MatrixSearch.DivideAndConquer, Matrix);

            var failedResult = MatrixSearch.DivideAndConquer(Matrix, 6);
            Assert.AreEqual((-1, -1), failedResult);
        }

        [TestMethod]
        public void OptimalImplementationWorks()
        {
            TestSearchMethod(MatrixSearch.Optimal, Matrix);

            var failedResult = MatrixSearch.Optimal(Matrix, 6);
            Assert.AreEqual((-1, -1), failedResult);
        }

        private static void TestSearchMethod(Func<int[,], int, (int, int)> func, int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); ++r)
            {
                for (int c = 0; c < matrix.GetLength(1); ++c)
                {
                    var result = func(matrix, matrix[r, c]);
                    Assert.AreEqual((r, c), result);
                }
            }
        }
    }
}
