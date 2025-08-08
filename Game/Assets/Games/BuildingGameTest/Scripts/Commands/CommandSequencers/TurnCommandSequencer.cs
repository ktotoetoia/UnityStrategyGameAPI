using System.Collections.Generic;
using TDS.Commands;
using TDS.Handlers;

namespace BuildingsTestGame
{
    public class TurnCommandSequencer : ITurnCommandSequencer
    {
        private readonly ICommandSequencer _commandSequencer;

        public IEnumerable<IConditionalHandler<ICommand>> Handlers => _commandSequencer.Handlers;
        
        public TurnCommandSequencer(ICommandSequencer commandSequencer)
        {
            _commandSequencer = commandSequencer;
        }

        public void IssueCommand(ICommand command)
        {
            _commandSequencer.IssueCommand(command);
        }
    }
}