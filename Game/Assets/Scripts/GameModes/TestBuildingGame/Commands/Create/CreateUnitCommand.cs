using System;
using TDS.Commands;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class CreateUnitCommand : Command
    {
        public AssignStageUnit UnitType { get; }
        public IProductionBuilding Building { get; }
        public IEntityRegister EntityRegister { get; }

        public IUnit CreatedUnit { get; set; }

        public CreateUnitCommand(AssignStageUnit unitType,
            IProductionBuilding building,
            IEntityRegister entityRegister)
        {
            UnitType = unitType;
            Building = building;
            EntityRegister = entityRegister;
        }

        public override void Finish(CommandStatus status)
        {
            base.Finish(status);
            
            if (status == CommandStatus.Success && CreatedUnit == null)
            {
                throw new Exception("CreateUnitCommand: CreatedUnit must be set before finishing");
            }
        }
    }
}