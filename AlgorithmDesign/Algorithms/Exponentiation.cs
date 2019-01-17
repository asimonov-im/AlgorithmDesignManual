namespace AlgorithmDesign.Algorithms
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class Exponentiation
    {
        public static uint DivideAndConquer(uint b, uint e)
        {
            if (e == 0) return 1;

            uint x = DivideAndConquer(b, e / 2);
            return e % 2 == 0 ? x * x : x * x * b;
        }
    }
}
