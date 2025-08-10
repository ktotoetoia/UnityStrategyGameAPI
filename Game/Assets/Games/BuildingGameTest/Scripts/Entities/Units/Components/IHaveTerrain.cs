using TDS.Components;
using TDS.Maps;

namespace BuildingsTestGame
{
    public interface IHaveTerrain : IComponent
    {
        IGameTerrainComponent Terrain { get; set; }
    }
}