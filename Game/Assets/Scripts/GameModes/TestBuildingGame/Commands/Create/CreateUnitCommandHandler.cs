using TDS.Commands;
using TDS.Handlers;

namespace BuildingsTestGame
{
    public class CreateUnitCommandHandler  : IHandler<ICommand>
    {
        public bool CanHandle(ICommand command)
        {
            return command is AddUnitCreationToBuildingQueue;
        }

        public void Handle(ICommand command)
        {
            if (command is AddUnitCreationToBuildingQueue createUnitCommand)
            {            
                createUnitCommand.Building.AddToQueue(createUnitCommand.EntityFactory);
            }
        }
    }
}