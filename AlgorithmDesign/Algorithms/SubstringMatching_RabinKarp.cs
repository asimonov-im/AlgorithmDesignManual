namespace AlgorithmDesign.Algorithms
{
    public static partial class SubstringMatching
    {
        public static int RabinKarp(string text, string pattern)
        {
            if (text.Length >= pattern.Length)
            {
                var hasher = new RollingHash(397, 7177);
                var pHash = hasher.Hash(pattern);

                foreach (var w in hasher.Rolling(text, pattern.Length))
                {
                    if (w.hash == pHash && IsMatch(pattern, text, w.idx))
                    {
                        return w.idx;
                    }
                }
            }

            return -1;
        }

        public static bool IsMatch(string pattern, string text, int textIndex)
        {
            return string.Compare(pattern, 0, text, textIndex, pattern.Length) == 0;
        }
    }
}
