namespace AlgorithmDesign.Exercises.Chapter8
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StringShuffle
    {
        private readonly string strX;
        private readonly string strY;
        private readonly string strZ;

        private readonly bool[,] DP;

        private StringShuffle(string strX, string strY, string strZ)
        {
            if (strX.Length + strY.Length != strZ.Length)
            {
                throw new ArgumentException("Expectected strZ.Length == strX.Length + strY.Length.");
            }

            this.strX = strX;
            this.strY = strY;
            this.strZ = strZ;

            DP = new bool[strX.Length + 1, strY.Length + 1];

            // Base case: both strings empty
            DP[0, 0] = true;

            // Base case: strX is empty
            for (int j = 1; j <= strY.Length; ++j)
            {
                DP[0, j] = DP[0, j - 1] && strY[j - 1] == strZ[j - 1];
            }

            // Base case: strY is empty
            for (int i = 1; i <= strX.Length; ++i)
            {
                DP[i, 0] = DP[i - 1, 0] && strX[i - 1] == strZ[i - 1];
            }
        }

        private bool Check()
        {
            ComputeDP();

            return DP[strX.Length, strY.Length];
        }

        private void ComputeDP()
        {
            for (int i = 1; i <= strX.Length; ++i)
            {
                for (int j = 1; j <= strY.Length; ++j)
                {
                    DP[i, j] = (strX[i - 1] == strZ[i + j - 1] && DP[i - 1, j]) ||
                               (strY[j - 1] == strZ[i + j - 1] && DP[i, j - 1]);
                }
            }
        }

        /// <summary>
        /// Returns true if strZ is a shuffle of strA and strB.
        /// </summary>
        /// <returns></returns>
        public static bool Check(string strX, string strY, string strZ)
        {
            if (strX.Length + strY.Length != strZ.Length)
            {
                return false;
            }
            else
            {
                return new StringShuffle(strX, strY, strZ).Check();
            }
        }
    }
}
