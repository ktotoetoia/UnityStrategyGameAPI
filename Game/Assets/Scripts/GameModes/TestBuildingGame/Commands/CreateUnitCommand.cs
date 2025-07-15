using TDS.Commands;
using TDS.Entities;

namespace BuildingsTestGame
{
    public record CreateUnitCommand(AssignStageUnit UnitType, IProductionBuilding Building, IEntityRegister EntityRegister) : ICommand;
}