using TDS.Components;
using TDS.Entities;
using TDS.Events;

namespace BuildingsTestGame
{
    public class TerrainComponent : Component, ITerrainComponent
    {
        private ICallPropertyChange<IGameTerrain> _terrain;

        private ICallPropertyChange<IGameTerrain> _terrainEvent =>
            _terrain ??= new CallPropertyChange<IGameTerrain, ITerrainComponent>(this,Entity.GetComponent<IEventComponent>());

        public IGameTerrain Terrain
        {
            get => _terrainEvent.Value;
            set
            {
                ThrowExceptionIfDestroyed();
                _terrainEvent.Value = value;
                Entity.Transform.SetPosition(value.Area.Position);
            }
        }
    }
}