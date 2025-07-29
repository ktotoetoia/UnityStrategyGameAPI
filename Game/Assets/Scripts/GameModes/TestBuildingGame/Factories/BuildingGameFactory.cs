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
            
            return new BuildingGame(CreateMap(bus),bus);
        }

        private IMap CreateMap(IEventBus bus)
        {
            RectangleMap map = new RectangleMap(TileCount,new BuildingTerrainFactory(bus));
            
            SetBase(map);

            return map;
        }

        private void SetBase(RectangleMap map)
        {
            ((BuildingTerrain)map.TerrainsMatrix[StartingPosition.x, StartingPosition.y]).Building = new FirstBuilding();
        }
    }
}