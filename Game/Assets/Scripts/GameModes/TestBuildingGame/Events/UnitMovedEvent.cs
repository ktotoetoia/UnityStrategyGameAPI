using TDS.Events;

namespace BuildingsTestGame
{
    public class UnitMovedEvent : IEvent
    {
        public MoveUnitCommand Command { get; }
        
        public UnitMovedEvent(MoveUnitCommand moveUnitCommand)
        {
            Command = moveUnitCommand;
        }
    }
}