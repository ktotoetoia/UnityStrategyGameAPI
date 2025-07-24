using System;
using System.Collections.Generic;
using TDS.Commands;

namespace BuildingsTestGame
{
    public class SelectorCommandHandler : ICommandHandler
    {
        public bool CanDoCommand(ICommand command)
        {
            return command is SelectAtPositionCommand or SelectInBoundsCommand;
        }

        public ICommandStatus DoCommand(ICommand command)
        {            
            if (command is SelectAtPositionCommand selectAtPositionCommand)
            {
                selectAtPositionCommand.Selector.UpdateSelection(selectAtPositionCommand.Position);
                
                return new CommandStatus(Status.Success,command,this);
            }

            if (command is SelectInBoundsCommand inBoundsCommand)
            {
                inBoundsCommand.Selector.UpdateSelection(inBoundsCommand.Bounds);
                
                return new CommandStatus(Status.Success,command,this);
            }
            
            return new CommandStatus(Status.Failed,command,this);
        }

        public IEnumerable<ICommandStatus> UpdateCommands()
        {
            return Array.Empty<ICommandStatus>();
        }
    }
}