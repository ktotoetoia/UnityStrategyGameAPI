using System.Collections.Generic;

namespace TDS.Graphs
{
    public interface IGraphReadOnly<T>
    {
        IReadOnlyList<INode<T>> Nodes { get; }
        IReadOnlyList<IEdge<T>> Edges { get; }
    }
}