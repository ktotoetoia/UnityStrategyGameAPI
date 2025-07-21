using TDS.Commands;
using TDS.Entities;
using TDS.SelectionSystem;
using TDS.Worlds;

namespace BuildingsTestGame
{
    public class CreateUnitCommandHandler : CompositeCommandHandler.CommandHandler<CreateUnitCommand>
    {
        public override void DoCommand(ICommand command)
        {
            if (CanDoCommand(command, out CreateUnitCommand com))
            {
                IUnit unit = new DefaultUnit(){Name = "Default Unit"};
                
                com.EntityRegister.AddEntity(unit);
                com.Building.AddToQueue(unit);
            }
        }
    }
}