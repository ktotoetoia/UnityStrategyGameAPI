using System;
using System.Collections.Generic;
using TDS.Commands;
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
                throw new ArgumentException();
            }
            
            DefaultUnit unit = new DefaultUnit{Name = "Default Unit"};

            createUnitCommand.EntityRegister.AddEntity(unit);
            createUnitCommand.Building.AddToQueue(unit);
            
            CommandStatus status =  new CommandStatus(Status.Success,createUnitCommand, this);
            
            if (unit.TryGetComponent(out IEventComponent eventComponent))
            {
                eventComponent.Publish(new UnitCommandEvent(status));
            }
            
            return status;
        }

        public IEnumerable<ICommandStatus> UpdateCommands()
        {
            return Array.Empty<ICommandStatus>();
        }
    }
}