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
            EventsEntityRegistry entityRegistry = new EventsEntityRegistry();
            
            RectangleMap map = new RectangleMap(TileCount,new GameTerrainFactory(entityRegistry));
            
            return new BuildingGame(map,entityRegistry);
        }
    }
}