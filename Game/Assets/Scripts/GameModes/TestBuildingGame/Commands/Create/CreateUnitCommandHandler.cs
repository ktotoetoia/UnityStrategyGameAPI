using TDS.Commands;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class CreateUnitCommandHandler : CompositeCommandHandler.CommandHandler<CreateUnitCommand>
    {
        public override void DoCommand(ICommand command)
        {
            if (CanDoCommand(command, out CreateUnitCommand com))
            {
                IUnit unit = new DefaultUnit{Name = "Default Unit"};
                
                com.EntityRegister.AddEntity(unit);
                com.Building.AddToQueue(unit);
                
                com.CreatedUnit =  unit;
                com.Finish(CommandStatus.Success);
            }
        }
    }
}