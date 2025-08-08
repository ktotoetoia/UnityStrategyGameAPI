using System.Collections.Generic;
using TDS.Events;
using TDS.Handlers;

namespace TDS.Commands
{
    public class CommandSequencer : ICommandSequencer
    {
        public IList<IConditionalHandler<ICommand>> HandlersList { get; }
        public IEnumerable<IConditionalHandler<ICommand>> Handlers => HandlersList;
        
        public CommandSequencer() : this(new List<IConditionalHandler<ICommand>>())
        {
            
        }

        public CommandSequencer(IEnumerable<IConditionalHandler<ICommand>> handlers) : this(new List<IConditionalHandler<ICommand>>(handlers))
        {
            
        }

        public CommandSequencer(IList<IConditionalHandler<ICommand>> handlers)
        {
            HandlersList = handlers;
        }

        public void IssueCommand(ICommand command)
        {
            foreach (var handler in Handlers)
            {
                if (handler.TryHandle(command))
                {
                    return;
                }
            }
        }
    }
}