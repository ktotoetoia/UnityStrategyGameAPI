using TDS.Components;
using TDS.Maps;

namespace BuildingsTestGame
{
    public interface IPlacedOnTerrain : IComponent
    {
        IGameTerrainComponent PlacedOn { get; set; }
    }
}