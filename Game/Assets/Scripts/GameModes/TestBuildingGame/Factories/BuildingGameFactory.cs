using TDS;
using TDS.Events;
using TDS.Maps;
using UnityEngine;

namespace BuildingsTestGame
{
    public class BuildingGameFactory : IFactory<BuildingGame>
    {
        public Vector2Int TileCount { get; set; }
        public Vector2Int StartingPosition { get; set; }
        
        public BuildingGameFactory(Vector2Int tileCount)
        {
            TileCount = tileCount;
        }
        
        public BuildingGame Create()
        {
            IEventBus bus = new EventBus();
            RectangleMap map = CreateMap(bus);
            BuildingGame game = new BuildingGame(map, bus);
            FirstBuilding building = new FirstBuilding();
            
            ((IGameTerrain)map.TerrainsMatrix[StartingPosition.x, StartingPosition.y]).Building = building;
            
            game.EntityRegister.AddEntity(building);
            
            return game;
        }

        private RectangleMap CreateMap(IEventBus bus)
        {
            return new RectangleMap(TileCount,new BuildingTerrainFactory(bus));
        }

        private void SetBase(RectangleMap map)
        {
            ((IGameTerrain)map.TerrainsMatrix[StartingPosition.x, StartingPosition.y]).Building = new FirstBuilding();
        }
    }
}