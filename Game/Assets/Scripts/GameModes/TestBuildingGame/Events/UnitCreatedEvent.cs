using TDS.Events;

namespace BuildingsTestGame
{
    public class UnitCreatedEvent : IEvent
    {
        public IUnit Unit { get; }
        public IGameTerrain Terrain { get; }

        public UnitCreatedEvent(IUnit unit, IGameTerrain terrain)
        {
            Unit = unit;
            Terrain = terrain;
        }
    }

    public class UnitMovedEvent : IEvent
    {
        public MoveUnitCommand Command { get; }
        
        public UnitMovedEvent(MoveUnitCommand moveUnitCommand)
        {
            Command = moveUnitCommand;
        }
    }
}