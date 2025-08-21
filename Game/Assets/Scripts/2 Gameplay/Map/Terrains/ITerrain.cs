using TDS.Entities;

namespace TDS.Maps
{
    public interface ITerrain : IEntity
    {
        ITerrainArea TerrainArea { get; }
    }
}