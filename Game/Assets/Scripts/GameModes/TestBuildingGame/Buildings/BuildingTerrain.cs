using TDS.Entities;
using TDS.Events;
using TDS.Worlds;
using Terrain = TDS.Worlds.Terrain;

namespace BuildingsTestGame
{
    public class BuildingTerrain : Terrain
    {
        private readonly ICallPropertyChange<IBuilding,BuildingTerrain> _building;
        private readonly ICallPropertyChange<IUnit, BuildingTerrain> _unit;

        public IUnit Unit
        {
            get => _unit.Value;
            set => _unit.Value = value;
        }
        
        public IBuilding Building
        {
            get => _building.Value;
            set
            {
                _building.Value = value;   
                
                if (value != null) 
                {
                    value.Terrain = this;
                }
            }
        }
        
        public BuildingTerrain(IArea area) : base(area)
        {
            _building = new NoCallPropertyChange<IBuilding, BuildingTerrain>(this);
            _unit = new NoCallPropertyChange<IUnit, BuildingTerrain>(this);
        }

        public BuildingTerrain(IArea area, IEventBus eventBus) : base(area)
        {
            _building = new CallPropertyChange<IBuilding, BuildingTerrain>(this,eventBus);
            _unit = new CallPropertyChange<IUnit, BuildingTerrain>(this,eventBus);
        }
    }
}