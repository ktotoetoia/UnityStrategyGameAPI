using TDS.Commands;
using TDS.Entities;
using TDS.TurnSystem;
using TDS.Worlds;

namespace BuildingsTestGame
{
    public record CreateUnitCommand(AssignStageUnit UnitType, IProductionBuilding Building, IEntityRegister EntityRegister) : ICommand;
    public record EndTurnCommand(ITurnUserManual TurnUser) : ICommand;
    public record MoveUnitCommand(IUnit Unit,IPath<ITerrain> path) : ICommand;
}