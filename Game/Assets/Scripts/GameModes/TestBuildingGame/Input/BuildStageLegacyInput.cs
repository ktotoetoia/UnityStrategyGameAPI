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
        
        public void HandleInput(ICommandQueue handler)
        { 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                handler.Enqueue(new EndTurnCommand(_context.BuildStage));
            }
        }
    }
}