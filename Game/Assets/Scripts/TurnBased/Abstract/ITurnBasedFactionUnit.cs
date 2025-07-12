using TDS.Entities;

namespace TDS.TurnSystem
{
    public interface ITurnBasedFactionUnit : IFactionUnit, ITurnObject
    {
        TurnBasedMovementComponent Movement { get; }
    }
}