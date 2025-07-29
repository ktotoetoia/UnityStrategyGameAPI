using System;
using System.Collections.Generic;
using TDS.Commands;
using TDS.Events;
using TDS.Handlers;

namespace BuildingsTestGame
{
    public class EndTurnCommandHandler : IHandler<ICommand>
    {
        public bool CanHandle(ICommand command)
        {
            return command is EndTurnCommand;
        }

        public void Handle(ICommand command)
        {
            if (command is not EndTurnCommand com)
            {
                throw new ArgumentException();
            }
            
            com.TurnUser.EndTurn();
        }
    }
}