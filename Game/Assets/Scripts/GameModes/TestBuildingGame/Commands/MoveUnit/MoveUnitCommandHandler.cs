using TDS.Events;

namespace BuildingsTestGame
{
    public class MoveUnitCommandHandler : IEventHandler
    {
        public bool CanHandle(IEvent evt)
        {
            return evt is MoveUnitCommand command && command.Path.Start.Value is BuildingTerrain&& command.Path.End.Value is BuildingTerrain;
        }

        public void Handle(IEvent evt)
        {
            if (evt is MoveUnitCommand command && command.Path.Start.Value is BuildingTerrain t1 &&
                command.Path.End.Value is BuildingTerrain t2)
            {
                t1.Unit = null;
                t2.Unit = command.Unit;
            }
        }
    }
}