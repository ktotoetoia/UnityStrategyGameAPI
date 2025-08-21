using TDS;
using TDS.Entities;
using TDS.Maps;
using UnityEngine;

namespace BuildingsTestGame
{
    public class GameTerrainFactory : IFactory<GameTerrain,Bounds>
    {
        private IEntityRegistry _entityRegistry;

        public GameTerrainFactory(IEntityRegistry entityRegistry)
        {
            _entityRegistry = entityRegistry;
        }
        
        public GameTerrain Create(Bounds param1)
        {
            GameTerrain terrain =  new GameTerrain(new BoundsArea(param1)) {Name = "Building Terrain"};
            
            _entityRegistry.AddEntity(terrain);
            
            return terrain;
        }
    }
}