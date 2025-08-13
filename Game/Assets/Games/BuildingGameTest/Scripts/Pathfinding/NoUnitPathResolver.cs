using System.Collections.Generic;
using System.Linq;
using TDS.Entities;
using TDS.Graphs;
using TDS.Maps;

namespace BuildingsTestGame
{
    public class NoUnitPathResolver : IPathResolver
    {
        public bool CanPathThrough<T>(IEnumerable<INode<T>> path) where T : ITerrain
        {
            return path.Count(x => x.Value.GetComponent<IGameTerrainComponent>().Unit != null) <= 1;
        }
    }
}