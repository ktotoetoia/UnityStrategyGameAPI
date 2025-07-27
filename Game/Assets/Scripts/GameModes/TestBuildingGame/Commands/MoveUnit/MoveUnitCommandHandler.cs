using System;
using System.Collections.Generic;
using TDS.Commands;
using TDS.Entities;
using TDS.Events;

namespace BuildingsTestGame
{
    public class MoveUnitCommandHandler : ICommandHandler
    {
        public bool CanDoCommand(ICommand command)
        {
            return command is MoveUnitCommand moveUnitCommand &&
                   moveUnitCommand.Path.Start.Value is BuildingTerrain &&
                   moveUnitCommand.Path.End.Value is BuildingTerrain;
        }

        public ICommandStatus DoCommand(ICommand command)
        {
            if (command is MoveUnitCommand moveUnitCommand && moveUnitCommand.Path.Start.Value is BuildingTerrain t1 &&
                moveUnitCommand.Path.End.Value is BuildingTerrain t2)
            {
                t1.Unit = null;
                t2.Unit = moveUnitCommand.Unit;
                
                CommandStatus status = new CommandStatus(Status.Success,moveUnitCommand, this);

                if (moveUnitCommand.Unit.TryGetComponent(out IEventComponent eventComponent))
                {
                    eventComponent.Publish(new UnitCommandEvent(status));
                }
                
                return status;
            }

            return new CommandStatus(Status.Failed, command, this);
        }

        public IEnumerable<ICommandStatus> UpdateCommands()
        {
            return Array.Empty<ICommandStatus>();
        }
    }
}