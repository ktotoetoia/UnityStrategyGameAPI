using System.Collections.Generic;
using TDS.Graphs;
using TDS.Maps;

namespace TDS.Maps
{
    public interface IPathResolver
    {
        bool CanPathThrough<T>(IEnumerable<INode<T>> path) where T : ITerrain;
    }
}