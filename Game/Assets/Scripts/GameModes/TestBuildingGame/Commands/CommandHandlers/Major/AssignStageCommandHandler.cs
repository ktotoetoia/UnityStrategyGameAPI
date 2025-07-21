using System.Collections.Generic;
using TDS.Commands;
using TDS.TurnSystem;
using TDS.Worlds;
using UnityEngine;

namespace BuildingsTestGame
{
    public class AssignStageCommandHandler : ICommandHandler
    {
        private CompositeCommandHandler _commandHandler;
        
        public AssignStageCommandHandler()
        {
            List<ICommandHandler> _commandListeners = new List<ICommandHandler>()
            {
                new EndTurnCommandHandler(),
                new CreateUnitCommandHandler()
            };

            _commandHandler = new CompositeCommandHandler(_commandListeners);
        }
        
        public bool CanDoCommand(ICommand command)
        {
            return _commandHandler.CanDoCommand(command);
        }

        public void DoCommand(ICommand command)
        {
            _commandHandler.DoCommand(command);
        }
    }
}