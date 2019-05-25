namespace AlgorithmDesign.Exercises.Chapter8
{
    using System.Text;

    public class LongestCommonSubstring
    {
        private readonly string strA;
        private readonly string strB;

        /// <summary>
        /// DP[i, j] is the length of the longest common suffix of the first
        /// i characters of strA and the first j characters of strB.
        /// </summary>
        private readonly int[,] DP;

        private (int len, int i) P;

        private LongestCommonSubstring(string strA, string strB)
        {
            this.strA = strA;
            this.strB = strB;

            DP = new int[strA.Length + 1, strB.Length + 1];
        }

        private string Find()
        {
            ConstructDP();

            return ConstructSolution();
        }

        private void ConstructDP()
        {
            for (int i = 1; i <= strA.Length; ++i)
            {
                for (int j = 1; j <= strB.Length; ++j)
                {
                    if (strA[i - 1] == strB[j - 1])
                    {
                        DP[i, j] = DP[i - 1, j - 1] + 1;
                        if (DP[i, j] > P.len)
                        {
                            P = (DP[i, j], i);
                        }
                    }
                    else
                    {
                        DP[i, j] = 0;
                    }
                }
            }
        }

        private string ConstructSolution()
        {
            return strA.Substring(P.i - P.len, P.len);
        }

        public static string Find(string strA, string strB)
        {
            return new LongestCommonSubstring(strA, strB).Find();
        }
    }
}
