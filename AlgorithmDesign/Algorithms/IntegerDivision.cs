namespace AlgorithmDesign.Algorithms
{
    using System;

    public static class IntegerDivision
    {
        public static int Naive(int divident, int divisor)
        {
            bool negativeQuotient = IsQuotientNegative(divident, divisor);
            divident = Math.Abs(divident);
            divisor = Math.Abs(divisor);

            int quotient = 0;
            while (divident >= divisor)
            {
                divident -= divisor;
                quotient += 1;
            }

            return negativeQuotient ? -quotient : quotient;
        }

        public static int PowersOfTwoDecomposition(int divident, int divisor)
        {
            bool negativeQuotient = IsQuotientNegative(divident, divisor);
            divident = Math.Abs(divident);
            divisor = Math.Abs(divisor);

            int quotient = 0;
            int temp = 0;
            for (int i = (int)Math.Log(divident, 2); i >= 0; --i)
            {
                int partialDivident = temp + (divisor << i);
                if (partialDivident <= divident)
                {
                    temp = partialDivident;
                    quotient |= 1 << i;
                }
            }

            return negativeQuotient ? -quotient : quotient;
        }

        private static bool IsQuotientNegative(int divident, int divisor)
        {
            return (divident < 0) ^ (divisor < 0);
        }
    }
}
