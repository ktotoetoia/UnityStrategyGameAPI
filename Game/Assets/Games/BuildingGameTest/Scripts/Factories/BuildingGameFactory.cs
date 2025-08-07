using TDS;
using TDS.Events;
using TDS.Maps;
using UnityEngine;

namespace BuildingsTestGame
{
    public class BuildingGameFactory : IFactory<BuildingGame>
    {
        public Vector2Int TileCount { get; set; }
        
        public BuildingGameFactory(Vector2Int tileCount)
        {
            TileCount = tileCount;
        }
        
        public BuildingGame Create()
        {
            IEventBus bus = new EventBus();
            RectangleMap map = CreateMap(bus);
            
            return new BuildingGame(map, bus);
        }

        private RectangleMap CreateMap(IEventBus bus)
        {
            return new RectangleMap(TileCount,new BuildingTerrainFactory(bus));
        }
    }
}