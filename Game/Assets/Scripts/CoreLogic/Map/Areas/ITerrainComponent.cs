using TDS.Components;

namespace TDS.Maps
{
    public interface ITerrainComponent : IComponent
    {
        ITerrain Terrain { get; }
    }
}