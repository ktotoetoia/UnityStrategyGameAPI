using UnityEngine;

namespace TDS.Worlds
{
    public class BoundsTerrainFactory : IFactory<ITerrain, Bounds>
    {
        public ITerrain Create(Bounds param1)
        {
            return new Terrain(new BoundsArea(param1));
        }
    }
}