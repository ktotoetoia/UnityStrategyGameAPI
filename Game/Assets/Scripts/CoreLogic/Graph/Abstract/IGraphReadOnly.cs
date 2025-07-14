using System.Collections.Generic;

namespace TDS.Graphs
{
    public interface IGraphReadOnly
    {
        IReadOnlyList<INodeReadOnly> Nodes { get; }
        IReadOnlyList<IEdge> Edges { get; }
    }
}