using TDS.Commands;

namespace BuildingsTestGame
{
    public class MoveUnitCommandHandler : ICommandHandler
    {
        public bool CanDoCommand(ICommand command)
        {
            return command is MoveUnitCommand;
        }

        public void DoCommand(ICommand command)
        {
            if (command is MoveUnitCommand c && c.Path.Start.Value is BuildingTerrain t1 && c.Path.End.Value is BuildingTerrain t2)
            {
                t1.Unit = null;
                t2.Unit = c.Unit;
                
                c.Finish(CommandStatus.Success);
            }
        }
    }
}