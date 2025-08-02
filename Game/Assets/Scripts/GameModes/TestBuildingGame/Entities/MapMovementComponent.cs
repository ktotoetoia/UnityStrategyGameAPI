using Component = TDS.Components.Component;

namespace BuildingsTestGame
{
    public class MapMovementComponent : Component, IMapMovementComponent
    {
        private IGameTerrain _terrain;
        public float MovementPoints { get; set; } = 2;

        public IGameTerrain Terrain
        {
            get => _terrain;
            set
            {
                ThrowExceptionIfDestroyed();
                _terrain = value;
                Entity.Transform.SetPosition(value.Area.Position);
            }
        }
    }
}