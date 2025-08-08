using System.Collections.Generic;
using UnityEngine;

namespace TDS.Maps
{
    public interface IMap
    {
        IEnumerable<ITerrain> Terrains { get; }

        IEnumerable<ITerrain> GetTerrainsAt(Vector3 position);
    }
}