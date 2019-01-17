namespace AlgorithmDesign.Exercises.Chapter3
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class IntegerProduct
    {
        public static int[] ComputeProducts_V1(int[] X)
        {
            int n = X.Length;
            var P = new int[n];
            var Q = new int[n];

            P[0] = 1;
            for (int i = 1; i < n; ++i)
            {
                P[i] = P[i - 1] * X[i - 1];
            }

            Q[0] = 1;
            for (int i = 1; i < n; ++i)
            {
                Q[i] = Q[i - 1] * X[n - i];
            }

            var M = new int[n];
            for (int i = 0; i < n; ++i)
            {
                M[i] = P[i] * Q[n - i - 1];
            }

            return M;
        }

        public static int[] ComputeProducts_V2(int[] X)
        {
            int n = X.Length;

            var Q = new int[n];
            Q[n - 1] = 1;
            for (int i = n - 2; i >= 0; --i)
            {
                Q[i] = Q[i + 1] * X[i + 1];
            }

            var M = new int[n];
            int P = 1;
            for (int i = 0; i < n; ++i)
            {
                if (i > 0) P *= X[i - 1];
                M[i] = P * Q[i];
            }

            return M;
        }
    }
}
