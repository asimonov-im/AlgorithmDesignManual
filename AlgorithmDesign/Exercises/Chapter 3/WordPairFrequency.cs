namespace AlgorithmDesign.Exercises.Chapter3
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AlgorithmDesign.DataStructures;

    public static class WordPairFrequency
    {
        public static (string, int) FindMostFrequentWordPair(string text)
        {
            var trie = new Trie<int>();

            TrieNode<int> bestPair = null;
            string previousWord = null;
            foreach (var word in TokenizeWords(text))
            {
                if (previousWord != null)
                {
                    var pairNode = trie.Insert(previousWord + ' ' + word);
                    pairNode.Data += 1;

                    if (bestPair == null || bestPair.Data < pairNode.Data)
                    {
                        bestPair = pairNode;
                    }
                }

                previousWord = word;
            }

            return bestPair != null ? 
                (bestPair.ToString(), bestPair.Data) :
                (null, -1);
        }

        private static IEnumerable<string> TokenizeWords(string text)
        {
            var sb = new StringBuilder();
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    sb.Append(char.ToUpper(c));
                }
                else if (char.IsWhiteSpace(c) && sb.Length > 0)
                {
                    yield return sb.ToString();
                    sb.Clear();
                }
            }
        }
    }
}
