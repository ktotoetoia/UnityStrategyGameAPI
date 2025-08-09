using TDS.Components;
using TDS.Entities;
using TDS.Events;
using TDS.Maps;

namespace BuildingsTestGame
{
    public class MovementOnTerrain : Component, IMovementOnTerrain
    {
        private ICallPropertyChange<IGameTerrainComponent> _terrain;

        private ICallPropertyChange<IGameTerrainComponent> _terrainEvent =>
            _terrain ??= new CallPropertyChange<IGameTerrainComponent, IMovementOnTerrain>(this,Entity.GetComponent<IEventComponent>());

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
                _terrainEvent.Value = value;
                Entity.Transform.SetPosition(value.Entity.Transform.Position);
            }
        }
    }
}