using TDS.Events;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class CreateUnitCommandHandler  : IEventHandler
    {
        public bool CanHandle(IEvent evt)
        {
            return evt is CreateUnitCommand;
        }

        public void Handle(IEvent evt)
        {
            if (evt is not CreateUnitCommand command)
            {
                throw new System.ArgumentException();
            }
            
            IUnit unit = new DefaultUnit{Name = "Default Unit"};
                
            command.EntityRegister.AddEntity(unit);
            command.Building.AddToQueue(unit);
        }
    }
}