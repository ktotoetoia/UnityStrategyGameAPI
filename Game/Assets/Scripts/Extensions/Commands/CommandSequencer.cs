using System.Collections.Generic;
using TDS.Events;
using TDS.Handlers;

namespace TDS.Commands
{
    public class CommandSequencer : ICommandSequencer
    {
        public IList<IHandler<ICommand>> HandlersList { get; }
        public IEnumerable<IHandler<ICommand>> Handlers => HandlersList;
        
        public CommandSequencer() : this(new List<IHandler<ICommand>>())
        {
            
        }

        public CommandSequencer(IEnumerable<IHandler<ICommand>> handlers) : this(new List<IHandler<ICommand>>(handlers))
        {
            
        }

        public CommandSequencer(IList<IHandler<ICommand>> handlers)
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