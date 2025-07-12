using System.Collections.Generic;
using UnityEngine;

namespace TDS.Worlds
{
    public interface IMap
    {
        ICollection<ITerrain> Terrains { get; }

        IEnumerable<ITerrain> GetTerrainsAt(Vector3 position);
    }
}