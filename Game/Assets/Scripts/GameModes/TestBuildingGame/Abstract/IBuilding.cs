using TDS;
using TDS.Commands;

namespace BuildingsTestGame
{
    public interface IBuilding : IHaveName
    {
        BuildingTerrain Terrain { get; set; }
    }
}