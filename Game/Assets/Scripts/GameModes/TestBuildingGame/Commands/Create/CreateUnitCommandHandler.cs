using System;
using TDS.Commands;
using TDS.Entities;
using TDS.Handlers;

namespace BuildingsTestGame
{
    public class CreateUnitCommandHandler  : IHandler<ICommand>
    {
        public bool CanHandle(ICommand command)
        {
            return command is CreateUnitCommand;
        }

        public void Handle(ICommand command)
        {
            if (command is not CreateUnitCommand createUnitCommand)
            {
                throw new ArgumentException();
            }
            
            DefaultUnit unit = new DefaultUnit{Name = "Default Unit"};

            createUnitCommand.EntityRegister.AddEntity(unit);
            createUnitCommand.Building.AddToQueue(unit);
            
            if (unit.TryGetComponent(out IEventComponent eventComponent))
            {
                eventComponent.Publish(new CommandEvent<CreateUnitCommand>(createUnitCommand));
            }
        }
    }
}