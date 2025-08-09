using TDS.Components;

namespace BuildingsTestGame
{
    public interface IMapMovementComponent : IComponent
    {
        float MovementPoints { get; set; }
    }
}