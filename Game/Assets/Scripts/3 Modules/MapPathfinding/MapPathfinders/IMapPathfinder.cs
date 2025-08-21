using TDS.Graphs;
using TDS.Pathfinding;

namespace TDS.Maps
{
    public interface IMapPathfinder
    {
        ISubGraph<T> GetAvailableMovement<T>(INode<T> startNode, float maxDistance) where T : ITerrain;
        IPath<T> GetPath<T>(IGraphReadOnly<T> graph, INode<T> from, INode<T> to) where T : ITerrain;
        IPath<ITerrain> GetPath(INode<ITerrain> startNode, INode<ITerrain> to,float distance);
        IPath<ITerrain> GetPath(ITerrain startTerrain, ITerrain endTerrain,float distance);
    }
}