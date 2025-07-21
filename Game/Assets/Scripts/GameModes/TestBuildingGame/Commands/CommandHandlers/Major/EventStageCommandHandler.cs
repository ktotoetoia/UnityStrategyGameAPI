using System.Collections.Generic;
using TDS.Commands;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public class EventStageCommandHandler : ICommandHandler
    {        
        private TurnUser _user;
        private CompositeCommandHandler _commandHandler;
        
        public EventStageCommandHandler(IBuildingGameContext gameContext)
        {
            List<ICommandHandler> _commandListeners = new List<ICommandHandler>()
            {
                new ActionCommandHandler<EndTurnCommand>(x => gameContext.EventStage.EndTurn()),
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