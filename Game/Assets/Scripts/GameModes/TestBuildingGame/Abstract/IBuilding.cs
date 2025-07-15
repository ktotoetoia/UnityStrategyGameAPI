using TDS;
using TDS.Worlds;

namespace BuildingsTestGame
{
    public interface IBuilding : IHaveName
    {
        BuildingTerrain Terrain { get; set; }
    }
}