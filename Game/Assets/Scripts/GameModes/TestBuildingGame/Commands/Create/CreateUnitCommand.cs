using System;
using TDS.Events;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class CreateUnitCommand : IEvent
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