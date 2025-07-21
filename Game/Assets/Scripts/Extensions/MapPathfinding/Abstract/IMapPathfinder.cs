using TDS.Graphs;
using TDS.Worlds;

namespace BuildingsTestGame
{
    public interface IMapPathfinder
    {
        IGraphReadOnly<T> GetAvailableMovement<T>(INode<T> startNode, float maxDistance) where T : ITerrain;
        IPath<T> GetPath<T>(IGraphReadOnly<T> graph, INode<T> from, INode<T> to) where T : ITerrain;
    }
}