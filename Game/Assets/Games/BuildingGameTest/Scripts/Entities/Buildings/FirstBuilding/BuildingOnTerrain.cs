using TDS.Events;
using Component = TDS.Components.Component;

namespace BuildingsTestGame
{
    public class BuildingOnTerrain : Component, IPlacedOnTerrain
    {        
        [BackingProperty(nameof(PlacedOn))] private readonly ICallPropertyChange<IGameTerrainComponent>_terrain;

        public IGameTerrainComponent PlacedOn
        {
            get
            {
                ThrowExceptionIfDestroyed();
                return _terrain.Value;  
            } 
        }

        public BuildingOnTerrain()
        {
            _terrain = new CallPropertyChange<IGameTerrainComponent>(this);
        }

        public void MoveTo(IGameTerrainComponent component)
        {
            ThrowExceptionIfDestroyed();
                
            if (_terrain.Value != null)
            {
                _terrain.Value.Building = null;
            }
                
            component.Building = Entity;
            Entity.Transform.SetPosition(component.Entity.Transform.Position);
            _terrain.Value = component;
        }
    }
}