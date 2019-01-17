namespace AlgorithmDesign.DataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Trie<T>
    {
        private TrieNode Root { get; }

        public int NodeCount { get; private set; }

        public Trie()
        {
            Root = new TrieNode('^');
        }

        public TrieNode Insert(string prefix)
        {
            if (string.IsNullOrEmpty(prefix))
            {
                throw new ArgumentException("Argument must not be null or empty.");
            }

            var node = Root;
            foreach (char c in prefix)
            {
                var nextNode = node.GetChild(c);
                if (nextNode == null)
                {
                    nextNode = new TrieNode(c);
                    node.AddChild(nextNode);
                    ++NodeCount;
                }

                node = nextNode;
            }
            node.IsTerminal = true;

            return node;
        }

        public bool Remove(string prefix)
        {
            if (string.IsNullOrEmpty(prefix))
            {
                throw new ArgumentException("Argument must not be null or empty.");
            }

            var foundNode = Find(prefix);

            var node = foundNode;
            while (node != null && node.IsLeaf)
            {
                node.Parent.RemoveChild(node);
                node = node.Parent;
                --NodeCount;
            }

            return foundNode != null;
        }

        public TrieNode Find(string prefix)
        {
            var node = FindInternal(prefix);
            return node.IsTerminal ? node : null;
        }

        private TrieNode FindInternal(string prefix)
        {
            if (string.IsNullOrEmpty(prefix))
            {
                throw new ArgumentException("Argument must not be null or empty.");
            }

            var node = Root;
            foreach (char c in prefix)
            {
                node = node.GetChild(c);
                if (node == null) break;
            }

            return node;
        }

        public class TrieNode
        {
            public TrieNode Parent { get; private set; }

            public char Value { get; }

            public T Data { get; set; }

            private List<TrieNode> Children { get; } = new List<TrieNode>();

            public bool IsLeaf => Children.Count == 0;

            public bool IsTerminal { get; internal set; }

            public override string ToString()
            {
                var sb = new StringBuilder();
                var node = this;
                while (node.Parent != null)
                {
                    sb.Append(node.Value);
                    node = node.Parent;
                }
                sb.Reverse();

                return sb.ToString();
            }

            internal TrieNode(char c)
            {
                Value = c;
            }

            internal TrieNode GetChild(char value)
            {
                return Children.Find(x => x.Value == value);
            }

            internal void AddChild(TrieNode child)
            {
                Children.Add(child);
                child.Parent = this;
            }

            internal bool RemoveChild(TrieNode child)
            {
                return Children.Remove(child);
            }
        }
    }
}
