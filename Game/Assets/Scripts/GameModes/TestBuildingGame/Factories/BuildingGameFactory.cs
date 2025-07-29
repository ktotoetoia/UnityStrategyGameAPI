using TDS;
using TDS.Events;
using TDS.Maps;
using UnityEngine;

namespace BuildingsTestGame
{
    public class BuildingGameFactory : IFactory<BuildingGame>
    {
        public Vector2Int TileCount { get; set; }
        public Vector3 TileSize { get; set; } = Vector3.one;
        public Vector2Int StartingPosition { get; set; }
        
        public BuildingGameFactory(Vector2Int tileCount)
        {
            TileCount = tileCount;
        }
        
        public BuildingGame Create()
        {
            IEventBus bus = new EventBus();
            
            return new BuildingGame(CreateMap(bus),bus);
        }

        private IMap CreateMap(IEventBus bus)
        {
            RectangleTileMap tileMap = new RectangleTileMap(TileCount,TileSize,new BuildingTerrainFactory(bus));
            
            SetBase(tileMap);

            return tileMap;
        }

        private void SetBase(RectangleTileMap tileMap)
        {
            ((BuildingTerrain)tileMap.TerrainsMatrix[StartingPosition.x, StartingPosition.y]).Building = new FirstBuilding();
        }
    }
}