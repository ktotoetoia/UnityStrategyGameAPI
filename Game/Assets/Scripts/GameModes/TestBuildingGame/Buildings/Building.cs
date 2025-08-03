using TDS.Entities;

namespace BuildingsTestGame
{
    public class Building : Entity, IBuilding
    {
        public IGameTerrain Terrain { get; set; }
    }
}