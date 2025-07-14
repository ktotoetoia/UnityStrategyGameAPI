using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TDS.Worlds
{
    public class Map : IMap
    {
        public ICollection<ITerrain> Terrains { get; }

        public Map() : this(new List<ITerrain>())
        {
        }

        public Map(ICollection<ITerrain> terrains)
        {
            Terrains = terrains;    
        }
        
        public IEnumerable<ITerrain> GetTerrainsAt(Vector3 position)
        {
            return Terrains.Where(x => x.Area.Contains(position));
        }
    }
}