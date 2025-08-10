using TDS.Components;
using TDS.Entities;
using TDS.Events;

namespace BuildingsTestGame
{
    public class BuildingOnTerrain : Component, IHaveTerrain
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
                    _terrainEvent.Value.Building = null;
                }
                
                value.Building = Entity;
                Entity.Transform.SetPosition(value.Entity.Transform.Position);
                _terrainEvent.Value = value;
            }
        }
    }
}