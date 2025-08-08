using System.Collections.Generic;
using System.Linq;
using TDS.Commands;
using TDS.Handlers;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public class TurnCommandSequencer : ICommandSequencer
    {
        private readonly ICommandSequencer _commandSequencer;

        public IEnumerable<IHandler<ICommand>> Handlers => _commandSequencer.Handlers;
        
        public TurnCommandSequencer() : this(new List<IHandler<ICommand>>())
        {
            
        }

        public TurnCommandSequencer(IEnumerable<IHandler<ICommand>> handlers) : this(new List<IHandler<ICommand>>(handlers))
        {
            
        }

        public TurnCommandSequencer(IList<IHandler<ICommand>> handlers) : this(new CommandSequencer(handlers))
        {
            
        }

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