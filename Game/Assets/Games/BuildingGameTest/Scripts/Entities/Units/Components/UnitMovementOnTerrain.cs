using TDS.Components;
using TDS.Entities;
using TDS.Events;

namespace BuildingsTestGame
{
    public class UnitMovementOnTerrain : Component, IPlacedOnTerrain
    {
        private ICallPropertyChange<IGameTerrainComponent> _terrain;

        private ICallPropertyChange<IGameTerrainComponent> _terrainEvent =>
            _terrain ??= new CallPropertyChange<IGameTerrainComponent, IPlacedOnTerrain>(this,Entity.GetComponent<IEventComponent>());

        public IGameTerrainComponent PlacedOn
        {
            get
            {
                ThrowExceptionIfDestroyed();
                return _terrainEvent.Value;  
            } 
            set
            {
                ThrowExceptionIfDestroyed();
                
                if (_terrainEvent.Value != null)
                {
                    _terrainEvent.Value.Unit = null;
                }
                
                value.Unit = Entity;
                Entity.Transform.SetPosition(value.Entity.Transform.Position);
                _terrainEvent.Value = value;
            }
        }
    }
}