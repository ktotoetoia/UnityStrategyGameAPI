namespace BuildingsTestGame
{
    public class Building : IBuilding
    {
        public string Name { get; set; } = "First Building";
        public IGameTerrain Terrain { get; set; }
    }
}