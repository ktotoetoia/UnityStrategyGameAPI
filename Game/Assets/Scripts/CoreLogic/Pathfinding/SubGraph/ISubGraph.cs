using TDS.Graphs;

namespace TDS.Pathfinding
{
    public interface ISubGraph<T>
    {
        IGraphReadOnly<T> Graph { get; }
    }
}