using TDS.Entities;
using TDS.Maps;

namespace BuildingsTestGame
{
    public interface IGameTerrain : ITerrain
    {
        public IEntity Unit { get; set; }
        public IBuilding Building { get; set; }
    }
}