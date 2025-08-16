using TDS.Entities;
using TDS.Events;
using UnityEngine;
using Component = TDS.Components.Component;

namespace BuildingsTestGame
{
    public class UnitMovementOnTerrain : Component, IPlacedOnTerrain
    {
        [BackingProperty(nameof(PlacedOn))]
        private readonly ICallPropertyChange<IGameTerrainComponent> _terrain;
        
        public IGameTerrainComponent PlacedOn
        {
            get
            {
                ThrowExceptionIfDestroyed();
                return _terrain.Value;  
            } 
            set
            {
                ThrowExceptionIfDestroyed();
                
                if (_terrain.Value != null)
                {
                    _terrain.Value.Unit = null;
                }
                
                value.Unit = Entity;
                Entity.Transform.SetPosition(value.Entity.Transform.Position);
                _terrain.Value = value;
            }
        }
        
        public UnitMovementOnTerrain()
        {
            _terrain = new CallPropertyChange<IGameTerrainComponent>(this);
        }
    }
}