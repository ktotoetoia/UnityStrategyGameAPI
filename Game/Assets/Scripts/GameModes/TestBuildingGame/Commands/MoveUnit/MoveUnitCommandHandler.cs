using System;
using System.Collections.Generic;
using TDS.Commands;
using TDS.Entities;
using TDS.Events;
using TDS.Handlers;

namespace BuildingsTestGame
{
    public class MoveUnitCommandHandler : IHandler<ICommand>
    {
        public bool CanHandle(ICommand command)
        {
            return command is MoveUnitCommand moveUnitCommand &&
                   moveUnitCommand.Path.Start.Value is BuildingTerrain &&
                   moveUnitCommand.Path.End.Value is BuildingTerrain;
        }

        public void Handle(ICommand command)
        {
            if (command is MoveUnitCommand moveUnitCommand && moveUnitCommand.Path.Start.Value is BuildingTerrain t1 &&
                moveUnitCommand.Path.End.Value is BuildingTerrain t2)
            {
                t1.Unit = null;
                t2.Unit = moveUnitCommand.Unit;
                
                if (moveUnitCommand.Unit.TryGetComponent(out IEventComponent eventComponent))
                {
                    eventComponent.Publish(new CommandEvent<MoveUnitCommand>(moveUnitCommand));
                }
            }
        }
    }
}