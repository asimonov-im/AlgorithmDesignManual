using System;

namespace AlgorithmDesign.Exercises.Chapter3
{
    public static class ReverseWordsInSentence
    {
        public static string Reverse(string sentence)
        {
            char[] chars = sentence.ToCharArray();
            Array.Reverse(chars);

            int lastCharIdx = chars.Length - 1;
            int wordStartIdx = -1;
            for (int i = 0; i <= lastCharIdx; ++i)
            {
                if (wordStartIdx >= 0 && char.IsWhiteSpace(chars[i]))
                {
                    Array.Reverse(chars, wordStartIdx, i - wordStartIdx);
                    wordStartIdx = -1;

                }
                else if (wordStartIdx < 0 && !char.IsWhiteSpace(chars[i]))
                {
                    wordStartIdx = i;
                }
            }

            if (wordStartIdx >= 0)
            {
                Array.Reverse(chars, wordStartIdx, lastCharIdx - wordStartIdx + 1);
            }

            return new string(chars);
        }
    }
}
