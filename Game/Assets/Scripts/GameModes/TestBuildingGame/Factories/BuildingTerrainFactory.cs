using TDS;
using TDS.Worlds;
using UnityEngine;

namespace BuildingsTestGame
{
    public class BuildingTerrainFactory : IFactory<BuildingTerrain,Bounds>
    {
        public BuildingTerrain Create(Bounds param1)
        {
            return new BuildingTerrain(new BoundsArea(param1)) {Name = "Building Terrain"};
        }
    }
}