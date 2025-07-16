using System;

namespace TDS.Graphs
{
    public class Edge<T> : IEdge, IValue<T>
    {
        public T Value { get; set; }
        public INode From { get; }
        public INode To { get; }

        public Edge(INode from, INode to) : this(from, to, default)
        {
        }

        public Edge(INode from, INode to, T value)
        {
            From = from;
            To = to;
            Value = value;
        }

        public INode GetOther(INode node)
        {
            if (node == null || (node != From && node != To)) throw new ArgumentException();

            return node == From ? To : From;
        }
    }

    public class Edge : Edge<object>
    {
        public Edge(INode from, INode to) : base(from, to)
        {
        }
    }
}