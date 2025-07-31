using TDS.Maps;
using TDS.Components;

namespace BuildingsTestGame
{
    public class MapMovementComponent : Component, IMapMovementComponent
    {
        public float MovementPoints { get; set; } = 2;
        public IGameTerrain Terrain { get; set; }
        
        public void MoveTo(IGameTerrain terrain)
        {
            ThrowExceptionIfDestroyed();
            
            Terrain = terrain;
            Entity.Transform.SetPosition(terrain.Area.Position);
        }
    }
}