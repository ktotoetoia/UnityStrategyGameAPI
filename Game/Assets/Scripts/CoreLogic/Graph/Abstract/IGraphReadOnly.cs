using System.Collections.Generic;

namespace TDS.Graphs
{
    public interface IGraphReadOnly
    {
        IReadOnlyList<INode> Nodes { get; }
        IReadOnlyList<IEdge> Edges { get; }
    }
}