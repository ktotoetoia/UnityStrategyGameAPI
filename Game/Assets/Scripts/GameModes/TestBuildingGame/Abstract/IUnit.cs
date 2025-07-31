using TDS.Entities;

namespace BuildingsTestGame
{
    public interface IUnit : IEntity
    {
        public IEventComponent Events { get; }
        public IMapMovementComponent MapMovement { get; }
    }
}