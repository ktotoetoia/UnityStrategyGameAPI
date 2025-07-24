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
        
        public void HandleInput(IEventBus handler)
        { 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                handler.Publish(new EndTurnCommand(_context.BuildStage));
            }
        }
    }
}