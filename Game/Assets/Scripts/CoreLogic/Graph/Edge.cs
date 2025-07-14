using System;

namespace TDS.Graphs
{
    public class Edge<T> : IEdge, IValue<T>
    {
        public T Value { get; set; }
        public INodeReadOnly From { get; }
        public INodeReadOnly To { get; }

        public Edge(INodeReadOnly from, INodeReadOnly to) : this(from, to, default)
        {
        }

        public Edge(INodeReadOnly from, INodeReadOnly to, T value)
        {
            From = from;
            To = to;
            Value = value;
        }

        public INodeReadOnly GetOther(INodeReadOnly node)
        {
            if (node == null || (node != From && node != To)) throw new ArgumentException();

            return node == From ? To : From;
        }
    }

    public class Edge : Edge<object>
    {
        public Edge(INodeReadOnly from, INodeReadOnly to) : base(from, to)
        {
        }
    }
}