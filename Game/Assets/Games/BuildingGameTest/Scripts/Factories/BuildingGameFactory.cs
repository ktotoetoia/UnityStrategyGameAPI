using TDS;
using TDS.Entities;
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
            EntityRegister entityRegister = new EntityRegister();
            EntityRegisterEvents events = new EntityRegisterEvents(entityRegister);
            
            RectangleMap map = new RectangleMap(TileCount,new GameTerrainFactory(entityRegister));
            
            return new BuildingGame(map,entityRegister,events);
        }
    }
}