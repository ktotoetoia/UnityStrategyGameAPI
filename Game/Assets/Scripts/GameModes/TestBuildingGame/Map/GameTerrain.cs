using System;
using TDS;
using TDS.Entities;
using TDS.Events;
using TDS.Maps;

namespace BuildingsTestGame
{
    public class GameTerrain : Terrain, IGameTerrain
    {
        private readonly ICallPropertyChange<IEntity,GameTerrain> _building;
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
                
                if (!value.TryGetComponent(out ITerrainComponent terrainComponent))
                {
                    throw new ArgumentException("unit does not have a map movement component");
                }
                
                if (_unit.Value != null)
                {
                    throw new ArgumentException("can not move unit to the terrain which already have a unit");
                }

                IGameTerrain from = terrainComponent.Terrain;
                
                if(from != null) from.Unit = null;
                
                _unit.Value = value;
                terrainComponent.Terrain = this;
            }
        }

        public IEntity Building
        {
            get => _building.Value;
            set
            {
                if (_building.Value != null && value != null)
                {
                    throw new ArgumentException("can not create a building on the terrain which already have a building");
                }
                
                _building.Value = value;
                
                if (value != null) value.GetComponent<ITerrainComponent>().Terrain = this;
            }
        }
        
        public GameTerrain(IArea area) : base(area)
        {
            _building = new NoCallPropertyChange<IEntity, GameTerrain>(this);
            _unit = new NoCallPropertyChange<IEntity, GameTerrain>(this);
        }

        public GameTerrain(IArea area, IEventBus eventBus) : base(area)
        {
            _building = new CallPropertyChange<IEntity, GameTerrain>(this,eventBus);
            _unit = new CallPropertyChange<IEntity, GameTerrain>(this,eventBus);
        }
    }
}