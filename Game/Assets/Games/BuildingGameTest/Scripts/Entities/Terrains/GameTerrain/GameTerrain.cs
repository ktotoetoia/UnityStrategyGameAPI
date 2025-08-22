using TDS.Components;
using TDS.Maps;

namespace BuildingsTestGame
{
    public class GameTerrain : Terrain
    {
        public IGameTerrainComponent GameTerrainComponent { get; }

        public GameTerrain(ITerrainArea terrainArea) : base(terrainArea)
        {
            GameTerrainComponent = new GameTerrainComponent();
            AddComponent(new EventComponent());
            AddComponent(GameTerrainComponent);
        }
    }
}