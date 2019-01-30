namespace AlgorithmDesign.Exercises.Chapter4
{
    using System.Collections.Generic;

    public static class RedWhiteBlueSort
    {
        public enum Color
        {
            Red = 0,
            White = 1,
            Blue = 2
        }

        public static void Sort(List<Color> colors)
        {
            int partition = 0;
            for (int i = 0; i < colors.Count; ++i)
            {
                if (colors[i] == Color.Red)
                {
                    Utils.SwapElements(colors, i, partition);
                    ++partition;
                }
            }

            for (int i = partition; i < colors.Count; ++i)
            {
                if (colors[i] == Color.White)
                {
                    Utils.SwapElements(colors, i, partition);
                    ++partition;
                }
            }
        }
    }
}
