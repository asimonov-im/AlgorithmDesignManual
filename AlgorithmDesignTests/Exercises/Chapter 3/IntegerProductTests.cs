using System;
using System.Linq;
using AlgorithmDesign.Exercises.Chapter3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmDesignTests.Exercises.Chapter_3
{
    [TestClass]
    public class IntegerProductTests
    {
        private static readonly int[] Values 
            = Utils.RandomSequence(1, 10).Take(10).ToArray();

        [TestMethod]
        public void ProductsAreComputedCorrectly_V1()
        {
            var expected = ComputeProduct(Values);
            var actual = IntegerProduct.ComputeProducts_V1(Values);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductsAreComputedCorrectly_V2()
        {
            var expected = ComputeProduct(Values);
            var actual = IntegerProduct.ComputeProducts_V2(Values);

            CollectionAssert.AreEqual(expected, actual);
        }

        private static int[] ComputeProduct(int[] X)
        {
            int[] M = new int[X.Length];
            for (int i = 0; i < X.Length; ++i)
            {
                M[i] = 1;
                for (int j = 0; j < X.Length; ++j)
                {
                    if (i != j) M[i] *= X[j];
                }
            }

            return M;
        }
    }
}
