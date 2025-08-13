using TDS.Components;
using TDS.Entities;
using TDS.Events;

namespace BuildingsTestGame
{
    public class BuildingOnTerrain : Component, IPlacedOnTerrain
    {        
        private ICallPropertyChange<IGameTerrainComponent> _t;

        private ICallPropertyChange<IGameTerrainComponent> _terrain =>
            _t ??= new CallPropertyChange<IGameTerrainComponent, IPlacedOnTerrain>(this,Entity.GetComponent<IEventComponent>());

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
                    _terrain.Value.Building = null;
                }
                
                value.Building = Entity;
                Entity.Transform.SetPosition(value.Entity.Transform.Position);
                _terrain.Value = value;
            }
        }
    }
}