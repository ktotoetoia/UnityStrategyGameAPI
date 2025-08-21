using System.Collections.Generic;
using TDS.Graphs;

namespace TDS.Maps
{
    public class PathResolver : IPathResolver
    {
        public bool CanPathThrough<T>(IEnumerable<INode<T>> path) where T : ITerrain
        {
            return true;
        }
    }
}