using TDS.Components;
using TDS.Entities;

namespace TDS.Maps
{
    public class Terrain : Entity, ITerrain
    {
        public ITerrainArea TerrainArea { get; set; }

        public Terrain(ITerrainArea terrainArea) : base(terrainArea)
        {
            TerrainArea = terrainArea;
        }
    }
}