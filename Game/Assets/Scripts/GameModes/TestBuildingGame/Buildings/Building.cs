using TDS.Worlds;

namespace BuildingsTestGame
{
    public class Building : IBuilding
    {
        public string Name { get; set; } = "First Building";
        public BuildingTerrain Terrain { get; set; }
    }
}