using System;
using System.Collections.Generic;
using TDS.Commands;
using TDS.Events;

namespace BuildingsTestGame
{
    public class EndTurnCommandHandler : ICommandHandler
    {
        public bool CanDoCommand(ICommand command)
        {
            return command is EndTurnCommand;
        }

        public ICommandStatus DoCommand(ICommand command)
        {
            if (command is not EndTurnCommand com)
            {
                throw new ArgumentException();
            }
            
            com.TurnUser.EndTurn();
            return new CommandStatus(Status.Success, command, this);
        }

        public IEnumerable<ICommandStatus> UpdateCommands()
        {
            return Array.Empty<ICommandStatus>();
        }
    }
}