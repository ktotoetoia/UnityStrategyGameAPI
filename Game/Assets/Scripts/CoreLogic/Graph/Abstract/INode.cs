using System.Collections.Generic;

namespace TDS.Graphs
{
    public interface INode : INode<object>
    {
        
    }

    public interface INode<T> : IValue<T>
    {
        IEnumerable<IEdge> Edges { get; }
    }
}