using TDS.Components;
using TDS.Maps;

namespace BuildingsTestGame
{
    public interface IMovementOnTerrain : IComponent
    {
        IGameTerrainComponent Terrain { get; set; }
    }
}