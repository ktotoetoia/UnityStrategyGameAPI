using TDS;
using TDS.Events;
using TDS.Maps;
using UnityEngine;

namespace BuildingsTestGame
{
    public class BuildingGameFactory : IFactory<BuildingGame>
    {
        public Vector2Int Size { get; set; }
        public Vector2Int StartingPosition { get; set; }
        
        public BuildingGameFactory(Vector2Int size)
        {
            Size = size;
        }
        
        public BuildingGame Create()
        {
            IEventBus bus = new EventBus();
            
            return new BuildingGame(CreateMap(bus),bus);
        }

        private IMap CreateMap(IEventBus bus)
        {
            RectangleTileMap tileMap = new RectangleTileMap(Size,new BuildingTerrainFactory(bus));
            
            SetBase(tileMap);

            return tileMap;
        }

        private void SetBase(RectangleTileMap tileMap)
        {
            ((BuildingTerrain)tileMap.TerrainsMatrix[StartingPosition.x, StartingPosition.y]).Building = new FirstBuilding();
        }
    }
}