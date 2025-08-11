using TDS.Components;

namespace BuildingsTestGame
{
    public interface IMapMovementComponent : IComponent
    {
        float TotalMovementPoints { get; set; }
        float AvailableMovementPoints { get; set; }
    }
}