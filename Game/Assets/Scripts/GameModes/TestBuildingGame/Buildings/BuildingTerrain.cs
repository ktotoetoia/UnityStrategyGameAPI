using TDS.Entities;
using TDS.Events;
using TDS.Maps;
using Terrain = TDS.Maps.Terrain;

namespace BuildingsTestGame
{
    public class BuildingTerrain : Terrain
    {
        private readonly ICallPropertyChange<IBuilding,BuildingTerrain> _building;
        private readonly ICallPropertyChange<IEntity, BuildingTerrain> _unit;

        public IEntity Unit
        {
            get => _unit.Value;
            set
            { 
                _unit.Value = value;
                value?.Transform.SetPosition(Area.Position);
            }
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
            _unit = new NoCallPropertyChange<IEntity, BuildingTerrain>(this);
        }

        public BuildingTerrain(IArea area, IEventBus eventBus) : base(area)
        {
            _building = new CallPropertyChange<IBuilding, BuildingTerrain>(this,eventBus);
            _unit = new CallPropertyChange<IEntity, BuildingTerrain>(this,eventBus);
        }
    }
}