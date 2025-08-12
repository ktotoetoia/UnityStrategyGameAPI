using TDS;
using TDS.Entities;
using TDS.Maps;
using UnityEngine;

namespace BuildingsTestGame
{
    public class GameTerrainFactory : IFactory<GameTerrain,Bounds>
    {
        private IEntityRegister _entityRegister;

        public GameTerrainFactory(IEntityRegister entityRegister)
        {
            _entityRegister = entityRegister;
        }
        
        public GameTerrain Create(Bounds param1)
        {
            GameTerrain terrain =  new GameTerrain(new BoundsTerrain(param1)) {Name = "Building Terrain"};
            
            _entityRegister.AddEntity(terrain);
            
            return terrain;
        }
    }
}