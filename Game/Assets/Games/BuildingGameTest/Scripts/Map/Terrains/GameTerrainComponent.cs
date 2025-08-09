using System;
using TDS.Components;
using TDS.Entities;
using TDS.Events;
using TDS.Maps;

namespace BuildingsTestGame
{
    public class GameTerrainComponent : TerrainComponent, IGameTerrainComponent
    {
        private ICallPropertyChange<IEntity,IGameTerrainComponent> _building;
        private ICallPropertyChange<IEntity, IGameTerrainComponent> _unit;

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
                
                if (!value.TryGetComponent(out IMovementOnTerrain terrainComponent))
                {
                    throw new ArgumentException("unit does not have a map movement component");
                }
                
                if (_unit.Value != null)
                {
                    throw new ArgumentException("can not move unit to the terrain which already have a unit");
                }

                IGameTerrainComponent from = terrainComponent.Terrain;
                
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
                
                if (value != null) value.GetComponent<IMovementOnTerrain>().Terrain = this;
            }
        }

        public override void Init(IEntity entity)
        {
            base.Init(entity);

            if (Entity.TryGetComponent(out IEventComponent eventComponent))
            {
                _building = new CallPropertyChange<IEntity, IGameTerrainComponent>(this,eventComponent);
                _unit = new CallPropertyChange<IEntity, IGameTerrainComponent>(this,eventComponent);
                
                return;
            }
            
            _building = new NoCallPropertyChange<IEntity, IGameTerrainComponent>(this);
            _unit = new NoCallPropertyChange<IEntity, IGameTerrainComponent>(this);
        }
    }
}