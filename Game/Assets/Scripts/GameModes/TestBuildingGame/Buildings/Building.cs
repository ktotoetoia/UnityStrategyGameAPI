using TDS.Worlds;

namespace BuildingsTestGame
{
    public class Building : IBuilding
    {
        public string Name { get; set; }
        public BuildingTerrain Terrain { get; set; }
    }
}