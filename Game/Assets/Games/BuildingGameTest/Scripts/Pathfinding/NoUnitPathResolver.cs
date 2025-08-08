using System.Collections.Generic;
using System.Linq;
using BuildingsTestGame;
using TDS.Graphs;
using TDS.Maps;

namespace TDS
{
    public class NoUnitPathResolver : IPathResolver
    {
        public bool CanPathThrough<T>(IEnumerable<INode<T>> path) where T : ITerrain
        {
            return path.Count(x => (x.Value as IGameTerrain).Unit != null) <= 1;
        }
    }
}