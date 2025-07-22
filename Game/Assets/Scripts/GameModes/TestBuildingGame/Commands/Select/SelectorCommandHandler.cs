using TDS.Commands;

namespace BuildingsTestGame
{
    public class SelectorCommandHandler : ICommandHandler
    {
        public bool CanDoCommand(ICommand command)
        {
            return command is SelectAtPositionCommand or SelectInBoundsCommand;
        }

        public void DoCommand(ICommand command)
        {
            if (command is SelectAtPositionCommand position)
            {
                position.Selector.UpdateSelection(position.Position);
                position.Finish(CommandStatus.Success);
                
                return;
            }
            
            if (command is SelectInBoundsCommand bounds)
            {
                bounds.Selector.UpdateSelection(bounds.Bounds);
                bounds.Finish(CommandStatus.Success);
            }
        }
    }
}