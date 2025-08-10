using TDS.Components;
using TDS.Entities;
using TDS.Events;
using TDS.Maps;

namespace BuildingsTestGame
{
    public class UnitMovementOnTerrain : Component, IHaveTerrain
    {
        private ICallPropertyChange<IGameTerrainComponent> _terrain;

        private ICallPropertyChange<IGameTerrainComponent> _terrainEvent =>
            _terrain ??= new CallPropertyChange<IGameTerrainComponent, IHaveTerrain>(this,Entity.GetComponent<IEventComponent>());

        public IGameTerrainComponent Terrain
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