using TDS.Commands;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class CreateUnitCommandHandler  : IEventHandler<CreateUnitCommand>
    {
        public void Handle(CreateUnitCommand evt)
        {
            IUnit unit = new DefaultUnit{Name = "Default Unit"};
                
            evt.EntityRegister.AddEntity(unit);
            evt.Building.AddToQueue(unit);
        }
    }
}