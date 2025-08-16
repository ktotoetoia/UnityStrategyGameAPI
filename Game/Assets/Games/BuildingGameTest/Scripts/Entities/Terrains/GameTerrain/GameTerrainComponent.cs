using System;
using TDS.Entities;
using TDS.Events;
using TDS.Maps;

namespace BuildingsTestGame
{
    public class GameTerrainComponent : TerrainComponent, IGameTerrainComponent
    {
        [BackingProperty(nameof(Building))] private ICallPropertyChange<IEntity> _building;
        [BackingProperty(nameof(Unit))] private ICallPropertyChange<IEntity> _unit;

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
                
                if (_unit.Value != null)
                {
                    throw new ArgumentException("can not move unit to the terrain which already have a unit");
                }

                _unit.Value = value;
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
            }
        }

        public override void Init(IEntity entity)
        {
            base.Init(entity);

            _building = new CallPropertyChange<IEntity>(this);
            _unit = new CallPropertyChange<IEntity>(this);
        }
    }
}