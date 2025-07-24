using TDS;
using TDS.Events;
using TDS.Worlds;
using UnityEngine;

namespace BuildingsTestGame
{
    public class BuildingTerrainFactory : IFactory<BuildingTerrain,Bounds>
    {
        private IEventBus _eventBus;

        public BuildingTerrainFactory()
        {
            
        }
        
        public BuildingTerrainFactory(IEventBus bus)
        {
            _eventBus = bus;
        }
        
        public BuildingTerrain Create(Bounds param1)
        {
            if (_eventBus != null)
            {
                return new BuildingTerrain(new BoundsArea(param1), _eventBus) { Name = "Building Terrain" };
            }
            
            return new BuildingTerrain(new BoundsArea(param1)) {Name = "Building Terrain"};
        }
    }
}