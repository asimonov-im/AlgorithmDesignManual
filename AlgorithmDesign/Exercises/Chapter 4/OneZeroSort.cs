using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmDesign.Exercises.Chapter4
{
    public static class OneZeroSort
    {
        public static void Sort_V1(List<int> values)
        {
            int partition = 0;
            for (int i = 0; i < values.Count - 1; ++i)
            {
                if (values[i] == 0)
                {
                    Utils.SwapElements(values, i, partition);
                    ++partition;
                }
            }

            Utils.SwapElements(values, values.Count - 1, partition);
        }
    }
}
