namespace AlgorithmDesign.Exercises.Chapter8
{
    using System.Text;

    public class LongestCommonSubsequence
    {
        private enum Move
        {
            Match = 0,
            SkipA = 1,
            SkipB = 2,
        }

        private readonly string strA;
        private readonly string strB;

        /// <summary>
        /// DP[i, j] is the LCS of the first i characters of strA and the first j characters of strB;
        /// </summary>
        private readonly int[,] DP;
        private readonly Move[,] P;

        private LongestCommonSubsequence(string strA, string strB)
        {
            this.strA = strA;
            this.strB = strB;

            DP = new int[strA.Length + 1, strB.Length + 1];
            P = new Move[strA.Length + 1, strB.Length + 1];

            // Base case: LCS with one string being empty
        }

        private string Find()
        {
            ComputeDP();

            return ConstructSolution();
        }

        private void ComputeDP()
        {
            for (int i = 1; i < strA.Length; ++i)
            {
                for (int j = 1; j < strB.Length; ++j)
                {
                    if (strA[i - 1] == strB[j - 1])
                    {
                        DP[i, j] = DP[i - 1, j - 1] + 1;
                        P[i, j] = Move.Match;
                    }
                    else
                    {
                        if (DP[i - 1, j] > DP[i, j - 1])
                        {
                            DP[i, j] = DP[i - 1, j];
                            P[i, j] = Move.SkipA;
                        }
                        else
                        {
                            DP[i, j] = DP[i, j - 1];
                            P[i, j] = Move.SkipB;
                        }
                    }
                }
            }
        }

        private string ConstructSolution()
        {
            var result = new StringBuilder();

            int i = strA.Length;
            int j = strB.Length;
            while (i > 0 && j > 0)
            {
                switch (P[i, j])
                {
                    case Move.Match:
                        result.Append(strA[i - 1]);
                        --i;
                        --j;
                        break;
                    case Move.SkipA:
                        --i;
                        break;
                    case Move.SkipB:
                        --j;
                        break;
                }
            }

            result.Reverse();
            return result.ToString();
        }

        public static string Find(string a, string b)
        {
            return new LongestCommonSubsequence(a, b).Find();
        }
    }
}
