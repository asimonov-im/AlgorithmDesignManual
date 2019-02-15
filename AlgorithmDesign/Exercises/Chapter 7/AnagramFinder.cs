namespace AlgorithmDesign.Exercises.Chapter7
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AlgorithmDesign.DataStructures;

    public class AnagramFinder
    {
        private readonly CharCounter charCounter;
        private readonly Trie wordTrie;
        private TrieNode currentNode;
        private readonly List<string> words = new List<string>();

        public AnagramFinder(string str, Trie wordTrie)
        {
            this.wordTrie = wordTrie;
            charCounter = new CharCounter(str);
            currentNode = wordTrie.Root;
        }

        public IEnumerable<string> Get()
        {
            var result = Enumerable.Empty<string>();
            if (charCounter.Count == 0 && ReferenceEquals(currentNode, wordTrie.Root))
            {
                result = result.Append(ConstructSolution());
            }
            else
            {
                foreach (var child in currentNode.Children)
                {
                    if (!charCounter.Contains(child.Value)) continue;

                    charCounter.Decrement(child.Value);

                    if (child.IsTerminal)
                    {
                        words.Add(child.ToString());
                        currentNode = wordTrie.Root;

                        result = result.Concat(Get());

                        words.RemoveLast();
                    }

                    currentNode = child;
                    result = result.Concat(Get());
                    currentNode = child.Parent;

                    charCounter.Increment(child.Value);
                }
            }

            return result;
        }

        private string ConstructSolution()
        {
            return string.Join(" ", words);
        }

        private class CharCounter
        {
            private readonly byte[] counts = new byte[26];

            public int Count { get; private set; }

            public CharCounter(string str)
            {
                foreach (char c in str.ToLowerInvariant())
                {
                    if (c >= 'a' && c <= 'z') Increment(c);
                }
            }

            public void Increment(char c)
            {
                ++counts[c - 'a'];
                Count += 1;
            }

            public void Decrement(char c)
            {
                --counts[c - 'a'];
                Count -= 1;
            }

            public bool Contains(char c)
            {
                return counts[c - 'a'] > 0;
            }

            public IEnumerable<char> GetChars()
            {
                var result = new List<char>();
                for (int i = 0; i < counts.Length; ++i)
                {
                    if (counts[i] > 0)
                    {
                        result.Add(Convert.ToChar('a' + i));
                    }
                }

                return result;
            }
        }
    }
}
