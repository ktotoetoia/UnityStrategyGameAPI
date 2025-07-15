using TDS;
using TDS.Commands;
using UnityEngine;

namespace BuildingsTestGame
{
    public class AssignStageLegacyInput : IInputHandler
    {
        private IBuildingGameContext _context;
        
        public AssignStageLegacyInput(IBuildingGameContext context)
        {
            _context = context;
        }
        
        public void HandleInput(ICommandHandler handler)
        { 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                handler.DoCommand(new EndTurnCommand(_context.CurrentStage));
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                handler.DoCommand(new CreateUnitCommand(AssignStageUnit.Builder,(_context.Selector.Selection.First.Object as BuildingTerrain) .Building as IProductionBuilding,_context.World.EntityRegister));
            }
        }
    }
}