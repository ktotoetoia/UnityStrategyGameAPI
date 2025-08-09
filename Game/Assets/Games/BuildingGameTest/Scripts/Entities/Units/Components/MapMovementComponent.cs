using TDS.Components;

namespace BuildingsTestGame
{
    public class MapMovementComponent : Component, IMapMovementComponent
    {
        public float MovementPoints { get; set; } = 6;
    }
}