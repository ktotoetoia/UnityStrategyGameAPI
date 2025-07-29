using System.Collections.Generic;
using TDS.Events;
using TDS.Handlers;
using UnityEngine;

namespace TDS.Commands
{
    public class CommandSequencer : ICommandSequencer
    {
        private readonly IEventBus _eventBus;
        
        public IList<IHandler<ICommand>> HandlersList { get; }
        public IEventSubscriber CommandEvents => _eventBus;
        public IEnumerable<IHandler<ICommand>> Handlers => HandlersList;
        
        public CommandSequencer() : this(new EventBus(), new List<IHandler<ICommand>>())
        {
            
        }

        public CommandSequencer(IEventBus eventBus, IEnumerable<IHandler<ICommand>> handlers) : this(eventBus, new List<IHandler<ICommand>>(handlers))
        {
            
        }

        public CommandSequencer(IEventBus eventBus, IList<IHandler<ICommand>> handlers)
        {
            _eventBus = eventBus;
            HandlersList = new List<IHandler<ICommand>>(handlers);
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