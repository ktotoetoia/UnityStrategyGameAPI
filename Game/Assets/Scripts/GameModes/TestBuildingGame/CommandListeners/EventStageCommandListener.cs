using System.Collections.Generic;
using TDS.Commands;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public class EventStageCommandListener : ICommandListener
    {        
        private TurnUser _user;
        private CommandListener _commandListener;
        
        public EventStageCommandListener(TurnUser turnUser)
        {
            List<ICommandListener> _commandListeners = new List<ICommandListener>()
            {
                new ActionCommandListener<EndTurnCommand>(x => turnUser.EndTurn()),
            };

            _commandListener = new CommandListener(_commandListeners);
        }
        
        public bool CanDoCommand(ICommand command)
        {
            return _commandListener.CanDoCommand(command);
        }

        public void DoCommand(ICommand command)
        {
            _commandListener.DoCommand(command);
        }
    }
}