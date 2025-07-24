using System;
using System.Collections.Generic;
using TDS.Commands;
using TDS.Events;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class CreateUnitCommandHandler  : ICommandHandler
    {
        public bool CanDoCommand(ICommand command)
        {
            return command is CreateUnitCommand;
        }

        public ICommandStatus DoCommand(ICommand command)
        {
            if (command is not CreateUnitCommand createUnitCommand)
            {
                throw new System.ArgumentException();
            }
            
            IUnit unit = new DefaultUnit{Name = "Default Unit"};
                
            createUnitCommand.EntityRegister.AddEntity(unit);
            createUnitCommand.Building.AddToQueue(unit);
            
            return new CommandStatus(Status.Success,createUnitCommand, this);
        }

        public IEnumerable<ICommandStatus> UpdateCommands()
        {
            return Array.Empty<ICommandStatus>();
        }
    }
}