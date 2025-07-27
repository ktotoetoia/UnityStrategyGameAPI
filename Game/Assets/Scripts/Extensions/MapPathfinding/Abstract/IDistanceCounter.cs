using System.Collections.Generic;
using TDS.Graphs;
using TDS.Maps;

namespace BuildingsTestGame
{
    public interface IDistanceCounter
    {
        float GetDistance<T>(IEnumerable<INode<T>> path) where T : ITerrain;
        float GetDistance<T>(IEdge<T> edge) where T : ITerrain;
    }
}