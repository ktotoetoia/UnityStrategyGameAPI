using TDS;

namespace BuildingsTestGame
{
    public interface IBuilding : IHaveName
    {
        IGameTerrain Terrain { get; set; }
    }
}