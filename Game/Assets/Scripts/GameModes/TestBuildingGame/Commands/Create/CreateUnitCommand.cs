using TDS.Commands;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class CreateUnitCommand : Command
    {
        public AssignStageUnit UnitType { get; }
        public IProductionBuilding Building { get; }
        public IEntityRegister EntityRegister { get; }

        public CreateUnitCommand(AssignStageUnit unitType,
            IProductionBuilding building,
            IEntityRegister entityRegister)
        {
            UnitType = unitType;
            Building = building;
            EntityRegister = entityRegister;
        }
    }
}