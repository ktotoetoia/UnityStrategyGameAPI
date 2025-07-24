using TDS.Commands;
using TDS.Events;
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
        
        public void HandleInput(ICommandSequencer handler)
        { 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                handler.IssueCommand(new EndTurnCommand(_context.BuildStage));
            }
        }
    }
}