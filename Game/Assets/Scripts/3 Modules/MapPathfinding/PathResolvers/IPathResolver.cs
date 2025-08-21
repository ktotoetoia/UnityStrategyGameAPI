using System.Collections.Generic;
using TDS.Graphs;

namespace TDS.Maps
{
    public interface IPathResolver
    {
        bool CanPathThrough<T>(IEnumerable<INode<T>> path) where T : ITerrain;
    }
}