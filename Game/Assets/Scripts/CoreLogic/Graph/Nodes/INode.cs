using System.Collections.Generic;

namespace TDS.Graphs
{
    public interface INode<T> :IValue<T>
    {
        IEnumerable<IEdge<T>> Edges { get; }
    }
}