using TDS.Events;

namespace BuildingsTestGame
{
    public class SelectorCommandHandler : IEventHandler
    {
        public bool CanHandle(IEvent evt)
        {
            return evt is SelectAtPositionCommand or SelectInBoundsCommand;
        }

        public void Handle(IEvent evt)
        {
            if (evt is SelectAtPositionCommand command)
            {
                command.Selector.UpdateSelection(command.Position);
                
                return;
            }

            if (evt is SelectInBoundsCommand inBoundsCommand)
            {
                inBoundsCommand.Selector.UpdateSelection(inBoundsCommand.Bounds);
            }
        }
    }
}