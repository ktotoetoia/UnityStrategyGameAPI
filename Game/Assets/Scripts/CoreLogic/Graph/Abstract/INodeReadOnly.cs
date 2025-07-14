using System.Collections.Generic;

namespace TDS.Graphs
{
    public interface INodeReadOnly
    {
        IEnumerable<IEdge> Edges { get; }
    }
}