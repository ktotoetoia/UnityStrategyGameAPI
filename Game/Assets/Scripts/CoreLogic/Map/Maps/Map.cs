using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TDS.Maps
{
    public class Map : IMap
    {
        public ICollection<ITerrain> TerrainsCollection { get; }
        public IEnumerable<ITerrain> Terrains => TerrainsCollection;

        public Map() : this(new List<ITerrain>())
        {
        }

        public Map(ICollection<ITerrain> terrains)
        {
            TerrainsCollection = terrains;    
        }
        
        public IEnumerable<ITerrain> GetTerrainsAt(Vector3 position)
        {
            return Terrains.Where(x => x.Area.Contains(position));
        }
    }
}