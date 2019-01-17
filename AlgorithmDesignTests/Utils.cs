namespace AlgorithmDesignTests
{
    using System;
    using System.Collections.Generic;

    public static class Utils
    {
        public static IEnumerable<int> RandomSequence(int minValue, int maxValue)
        {
            Random rnd = new Random();
            while (true)
            {
                yield return rnd.Next(minValue, maxValue);
            }
        }
    }
}
