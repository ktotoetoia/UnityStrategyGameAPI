using System.Collections.Generic;
using TDS.Commands;
using TDS.TurnSystem;
using TDS.Worlds;

namespace BuildingsTestGame
{
    public class BuildStageCommandHandler : ICommandHandler
    {
        private TurnUser _user;
        private CompositeCommandHandler _commandHandler;
        
        public BuildStageCommandHandler()
        {
            List<ICommandHandler> _commandListeners = new List<ICommandHandler>()
            {
                new EndTurnCommandHandler(),
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