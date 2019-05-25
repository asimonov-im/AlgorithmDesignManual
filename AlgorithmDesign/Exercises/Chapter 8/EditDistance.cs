namespace AlgorithmDesign.Exercises.Chapter8
{
    using System.Collections.Generic;

    public class EditDistance
    {
        private readonly string text;
        private readonly string pattern;

        // Let DP[i, j] be the minimum edit distance between the first i character of the text
        // and the first j characters of the pattern.

        private readonly int[,] DP;
        private readonly EditType[,] P;

        public enum EditType
        {
            Match = 0,
            Replace = 1,
            Insert = 2,
            Delete = 3,
        }

        public static List<EditType> Get(string text, string pattern)
        {
            var helper = new EditDistance(text, pattern);
            return helper.GetEdits();
        }

        public EditDistance(string text, string pattern)
        {
            this.text = text;
            this.pattern = pattern;

            DP = new int[text.Length + 1, pattern.Length + 1];
            P = new EditType[text.Length + 1, pattern.Length + 1];

            // Base case: empty text
            for (int i = 1; i <= pattern.Length; ++i)
            {
                DP[0, i] = i;
                P[0, i] = EditType.Delete;
            }

            // Base case: empty pattern
            for (int i = 1; i <= text.Length; ++i)
            {
                DP[i, 0] = i;
                P[i, 0] = EditType.Insert;
            }
        }

        public List<EditType> GetEdits()
        {
            var costs = new (EditType, int)[3];
            for (int i = 1; i <= text.Length; ++i)
            {
                for (int j = 1; j <= pattern.Length; ++j)
                {
                    if (text[i - 1] == pattern[j - 1])
                    {
                        costs[0] = (EditType.Match, DP[i - 1, j - 1]);
                    }
                    else
                    {
                        costs[0] = (EditType.Replace, DP[i - 1, j - 1] + 1);
                    }
                    costs[1] = (EditType.Insert, DP[i - 1, j] + 1);
                    costs[2] = (EditType.Delete, DP[i, j - 1] + 1);

                    DP[i, j] = int.MaxValue;
                    foreach (var cost in costs)
                    {
                        if (cost.Item2 < DP[i, j])
                        {
                            DP[i, j] = cost.Item2;
                            P[i, j] = cost.Item1;
                        }
                    }
                }
            }

            return ReconstructEdits();
        }

        private List<EditType> ReconstructEdits()
        {
            var result = new List<EditType>();

            int i = text.Length;
            int j = pattern.Length;
            while (i > 0 || j > 0)
            {
                result.Add(P[i, j]);

                switch (P[i, j])
                {
                    case EditType.Match:
                    case EditType.Replace:
                        --i;
                        --j;
                        break;
                    case EditType.Insert:
                        --i;
                        break;
                    case EditType.Delete:
                        --j;
                        break;
                }
            }

            result.Reverse();

            return result;
        }

        private int MatchCost(int textIdx, int patternIdx)
            => text[textIdx] == pattern[patternIdx] ? 0 : 1;
    }
}
