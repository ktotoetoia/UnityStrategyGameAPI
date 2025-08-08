using TDS.Graphs;

namespace TDS.Pathfinding
{
    public class SubGraph<T> : ISubGraph<T>
    {
        public IGraphReadOnly<T> Graph { get; }

        public SubGraph(IGraphReadOnly<T> graph)
        {
            Graph = graph;
        }
    }
}