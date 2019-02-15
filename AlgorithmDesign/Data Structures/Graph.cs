namespace AlgorithmDesign.DataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class Graph<T>
    {
        private readonly List<GraphNode<T>> vertices = new List<GraphNode<T>>();

        public ReadOnlyCollection<GraphNode<T>> Vertices { get; }

        public bool AddVertex(GraphNode<T> vertex)
        {
            CheckNotNull(vertex, nameof(vertex));

            if (vertex.Graph != null && !ReferenceEquals(vertex.Graph, this))
            {
                throw new InvalidOperationException("Cannot add vertex belonging to a different Graph.");
            }

            bool newVertex = !Contains(vertex);
            if (newVertex)
            {
                vertex.Graph = this;
                vertices.Add(vertex);
            }

            return newVertex;
        }

        public void RemoveVertex(GraphNode<T> vertex)
        {
            CheckNotNull(vertex, nameof(vertex));
            CheckOwnership(vertex, nameof(vertex));

            foreach (var v in vertices)
            {
                v.RemoveNeightbor(vertex);
            }

            vertices.Remove(vertex);
            vertex.Graph = null;
        }

        public void AddDirectedEdge(GraphNode<T> fromVertex, GraphNode<T> toVertex)
        {
            AddEdge(fromVertex, toVertex, true);
        }

        public void AddUndirectedEdge(GraphNode<T> fromVertex, GraphNode<T> toVertex)
        {
            AddEdge(fromVertex, toVertex, false);
        }

        public void RemoveDirectedEdge(GraphNode<T> fromVertex, GraphNode<T> toVertex)
        {
            RemoveEdge(fromVertex, toVertex, true);
        }

        public void RemoveUndirectedEdge(GraphNode<T> fromVertex, GraphNode<T> toVertex)
        {
            RemoveEdge(fromVertex, toVertex, false);
        }

        public bool Contains(GraphNode<T> vertex)
        {
            CheckNotNull(vertex, nameof(vertex));

            return vertices.FindIndex(x => ReferenceEquals(x, vertex)) >= 0;
        }

        public static Graph<T> Create(IEnumerable<(T from, T to)> edges, bool isDirected)
        {
            var graph = new Graph<T>();
            var vertices = new Dictionary<T, GraphNode<T>>();

            foreach (var (fromValue, toValue) in edges)
            {
                GraphNode<T> fromVertex;
                if (!vertices.TryGetValue(fromValue, out fromVertex))
                {
                    fromVertex = new GraphNode<T>(fromValue);
                    vertices.Add(fromValue, fromVertex);
                    graph.vertices.Add(fromVertex);
                }

                GraphNode<T> toVertex;
                if (!vertices.TryGetValue(toValue, out toVertex))
                {
                    toVertex = new GraphNode<T>(toValue);
                    vertices.Add(toValue, toVertex);
                    graph.vertices.Add(toVertex);
                }

                fromVertex.AddNeighbor(toVertex);
                if (!isDirected) toVertex.AddNeighbor(fromVertex);
            }

            return graph;
        }

        private void AddEdge(GraphNode<T> fromVertex, GraphNode<T> toVertex, bool isDirected)
        {
            AddVertex(fromVertex);
            AddVertex(toVertex);

            fromVertex.AddNeighbor(toVertex);
            if (!isDirected) toVertex.AddNeighbor(fromVertex);
        }

        private void RemoveEdge(GraphNode<T> fromVertex, GraphNode<T> toVertex, bool isDirected)
        {
            CheckNotNull(fromVertex, nameof(fromVertex));
            CheckNotNull(toVertex, nameof(toVertex));

            CheckOwnership(fromVertex, nameof(fromVertex));
            CheckOwnership(toVertex, nameof(toVertex));

            fromVertex.RemoveNeightbor(toVertex);
            if (!isDirected) toVertex.RemoveNeightbor(fromVertex);
        }

        private void CheckNotNull(GraphNode<T> v, string paramName)
        {
            if (v == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        private void CheckOwnership(GraphNode<T> v, string paramName)
        {
            if (!ReferenceEquals(v.Graph, this))
            {
                throw new InvalidOperationException($"The {paramName} is not owned by the Graph.");
            }
        }
    }

    public class GraphNode<T>
    {
        private readonly List<GraphNode<T>> neighbors = new List<GraphNode<T>>();

        public Graph<T> Graph { get; internal set; }

        public T Value { get; }

        public ReadOnlyCollection<GraphNode<T>> Neighbors { get; }

        public GraphNode(T value)
        {
            this.Value = value;
            this.Neighbors = new ReadOnlyCollection<GraphNode<T>>(neighbors);
        }

        public bool HasNeighbor(GraphNode<T> vertex)
        {
            return neighbors.FindIndex(x => ReferenceEquals(x, vertex)) > 0;
        }

        internal void AddNeighbor(GraphNode<T> vertex)
        {
            if (!HasNeighbor(vertex))
            {
                neighbors.Add(vertex);
            }
        }

        internal void RemoveNeightbor(GraphNode<T> vertex)
        {
            neighbors.Remove(vertex);
        }
    }
}
