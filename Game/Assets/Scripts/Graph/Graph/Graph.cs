using System.Collections.Generic;

namespace TDS.Graphs
{
    public class Graph : IGraphReadOnly
    {
        public Graph(IReadOnlyList<INodeReadOnly> nodes, IReadOnlyList<IEdge> edges)
        {
            Nodes = nodes;
            Edges = edges;
        }

        public IReadOnlyList<INodeReadOnly> Nodes { get; }
        public IReadOnlyList<IEdge> Edges { get; }
    }
}