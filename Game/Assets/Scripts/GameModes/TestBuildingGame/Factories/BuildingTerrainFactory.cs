using TDS;
using TDS.Events;
using TDS.Maps;
using UnityEngine;

namespace BuildingsTestGame
{
    public class BuildingTerrainFactory : IFactory<GameTerrain,Bounds>
    {
        private IEventBus _eventBus;

        public BuildingTerrainFactory()
        {
            
        }
        
        public BuildingTerrainFactory(IEventBus bus)
        {
            _eventBus = bus;
        }
        
        public GameTerrain Create(Bounds param1)
        {
            if (_eventBus != null)
            {
                return new GameTerrain(new BoundsArea(param1), _eventBus) { Name = "Building Terrain" };
            }
            
            return new GameTerrain(new BoundsArea(param1)) {Name = "Building Terrain"};
        }
    }
}