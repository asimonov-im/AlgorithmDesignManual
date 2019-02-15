namespace AlgorithmDesign.DataStructures
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Trie : TrieBase<TrieNode>
    {
        public Trie()
            : base(c => new TrieNode(c))
        {
        }

        public static Trie FromWordFile(string filePath)
        {
            var trie = new Trie();
            foreach (var line in File.ReadLines(filePath))
            {
                trie.Insert(line);
            }

            return trie;
        }
    }

    public class Trie<T> : TrieBase<TrieNode<T>>
    {
        public Trie()
            : base(c => new TrieNode<T>(c))
        {
        }
    }

    public class TrieBase<NodeType>
        where NodeType : TrieNode
    {
        private readonly Func<char, NodeType> makeNode;

        public NodeType Root { get; }

        public int NodeCount { get; private set; }

        public TrieBase(Func<char, NodeType> makeNode)
        {
            this.makeNode = makeNode;
            Root = makeNode('^');
        }

        public NodeType Insert(string prefix)
        {
            if (string.IsNullOrEmpty(prefix))
            {
                throw new ArgumentException("Argument must not be null or empty.");
            }

            NodeType node = Root;
            foreach (char c in prefix)
            {
                NodeType nextNode = (NodeType)node.GetChild(c);
                if (nextNode == null)
                {
                    nextNode = makeNode(c);
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
                node = (NodeType)node.GetChild(c);
                if (node == null) break;
            }

            return node;
        }
    }

    public class TrieNode
    {
        private readonly List<TrieNode> children = new List<TrieNode>();

        public TrieNode Parent { get; private set; }

        public IEnumerable<TrieNode> Children => children;

        public char Value { get; }

        public bool IsLeaf => children.Count == 0;

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

        public TrieNode(char c)
        {
            Value = c;
        }

        public TrieNode GetChild(char value)
        {
            return children.Find(x => x.Value == value);
        }

        internal void AddChild(TrieNode child)
        {
            children.Add(child);
            child.Parent = this;
        }

        internal bool RemoveChild(TrieNode child)
        {
            return children.Remove(child);
        }
    }

    public class TrieNode<T> : TrieNode
    {
        public new TrieNode<T> Parent
            => (TrieNode<T>)base.Parent;

        public new IEnumerable<TrieNode<T>> Children
            => base.Children.Cast<TrieNode<T>>();

        public T Data { get; set; }

        public TrieNode(char c) : base(c)
        {
        }

        public new TrieNode<T> GetChild(char value)
        {
            return (TrieNode<T>)base.GetChild(value);
        }
    }
}
