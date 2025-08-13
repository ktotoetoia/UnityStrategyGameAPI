using TDS.Components;

namespace BuildingsTestGame
{
    public interface IPlacedOnTerrain : IComponent
    {
        IGameTerrainComponent PlacedOn { get; set; }
    }
}