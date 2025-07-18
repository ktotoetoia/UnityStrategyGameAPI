using TDS.Commands;
using UnityEngine;

namespace BuildingsTestGame
{
    public class BuildStageLegacyInput : IInputHandler
    {
        private IBuildingGameContext _context;
        
        public BuildStageLegacyInput(IBuildingGameContext context)
        {
            _context = context;
        }
        
        public void HandleInput(ICommandHandler handler)
        { 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                handler.DoCommand(new EndTurnCommand(_context.BuildStage));
            }
        }
    }
}