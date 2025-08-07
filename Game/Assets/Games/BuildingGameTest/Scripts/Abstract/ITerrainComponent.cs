using TDS.Components;

namespace BuildingsTestGame
{
    public interface ITerrainComponent : IComponent
    {
        IGameTerrain Terrain { get; set; }
    }
}