using System;
using System.Collections.Generic;
using System.Linq;

namespace TDS.Graphs
{
    public class BiDirectionalGraph : IGraph
    {
        private readonly List<IEdge> _edges;
        private readonly List<INodeReadOnly> _nodes;

        public BiDirectionalGraph()
        {
            _nodes = new List<INodeReadOnly>();
            _edges = new List<IEdge>();
        }

        public IReadOnlyList<IEdge> Edges => _edges;
        public IReadOnlyList<INodeReadOnly> Nodes => _nodes;

        public INodeReadOnly CreateNode()
        {
            var node = new Node();

            _nodes.Add(node);

            return node;
        }

        public void RemoveNode(INodeReadOnly node)
        {
            if (!_nodes.Contains(node)) throw new ArgumentException();

            foreach (var edge in node.Edges.ToList()) Disconnect(edge);

            _nodes.Remove(node);
        }

        public IEdge Connect(INodeReadOnly first, INodeReadOnly second)
        {
            if (!_nodes.Contains(first) || !_nodes.Contains(second)) throw new ArgumentException();

            var edge = new Edge(first, second);

            (first as Node).Add(edge);
            (second as Node).Add(edge);
            _edges.Add(edge);

            return edge;
        }

        public void Disconnect(IEdge edge)
        {
            if (!_edges.Contains(edge) || !_nodes.Contains(edge.From) || !_nodes.Contains(edge.To))
                throw new ArgumentException();

            (edge.From as INode).Remove(edge);
            (edge.To as INode).Remove(edge);

            _edges.Remove(edge);
        }
    }
}