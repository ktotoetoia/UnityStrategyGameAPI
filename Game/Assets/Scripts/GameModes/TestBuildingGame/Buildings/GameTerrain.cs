using System;
using TDS.Entities;
using TDS.Events;
using TDS.Maps;

namespace BuildingsTestGame
{
    public class GameTerrain : Terrain, IGameTerrain
    {
        private readonly ICallPropertyChange<IBuilding,GameTerrain> _building;
        private readonly ICallPropertyChange<IEntity, GameTerrain> _unit;

        public IEntity Unit
        {
            get => _unit.Value;
            set
            {
                if (value == null)
                {
                    _unit.Value = null;
                
                    return;
                }
                
                if (!value.TryGetComponent(out IMapMovementComponent mapMovement))
                {
                    throw new ArgumentException("unit does not have a map movement component");
                }
                
                if (_unit.Value != null)
                {
                    throw new ArgumentException("can not move unit to the terrain which already have a unit");
                }

                IGameTerrain from = mapMovement.Terrain;
                
                if(from != null) from.Unit = null;
                
                _unit.Value = value;
                mapMovement.Terrain = this;
            }
        }

        public IBuilding Building
        {
            get => _building.Value;
            set
            {
                if (_building.Value != null && value != null)
                {
                    throw new ArgumentException("can not create a building on the terrain which already have a building");
                }
                
                _building.Value = value;
                
                if (value != null) value.Terrain = this;
            }
        }
        
        public GameTerrain(IArea area) : base(area)
        {
            _building = new NoCallPropertyChange<IBuilding, GameTerrain>(this);
            _unit = new NoCallPropertyChange<IEntity, GameTerrain>(this);
        }

        public GameTerrain(IArea area, IEventBus eventBus) : base(area)
        {
            _building = new CallPropertyChange<IBuilding, GameTerrain>(this,eventBus);
            _unit = new CallPropertyChange<IEntity, GameTerrain>(this,eventBus);
        }
    }
}