using TDS.Components;
using TDS.Events;

namespace BuildingsTestGame
{
    public class BuildingOnTerrain : Component, IPlacedOnTerrain
    {        
        [BackingProperty(nameof(PlacedOn))] private ICallPropertyChange<IGameTerrainComponent>_terrain;

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

        public BuildingOnTerrain()
        {
            _terrain = new CallPropertyChange<IGameTerrainComponent>(this);
        }
    }
}