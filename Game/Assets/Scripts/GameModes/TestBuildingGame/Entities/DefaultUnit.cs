using TDS.Entities;

namespace BuildingsTestGame
{
    public class DefaultUnit : Entity, IUnit
    {
        public IEventComponent Events { get; }
        public IMapMovementComponent MapMovement { get; }
        
        public DefaultUnit()
        {
            Name = "Default Unit";
            Events = new EventComponent();
            AddComponent(Events);
            MapMovement = new MapMovementComponent();
            AddComponent(MapMovement);
        }
    }
}