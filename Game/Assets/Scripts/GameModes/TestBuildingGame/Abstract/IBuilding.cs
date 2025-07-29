using TDS;

namespace BuildingsTestGame
{
    public interface IBuilding : IHaveName
    {
        BuildingTerrain Terrain { get; set; }
    }
}