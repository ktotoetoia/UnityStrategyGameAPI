using System.Collections.Generic;
using TDS.Events;
using UnityEngine;

namespace TDS.Commands
{
    public class CommandSequencer : ICommandSequencer
    {
        private readonly IEventBus _eventBus;
        
        public IList<ICommandHandler> HandlersList { get; }
        public IEventSubscriber CommandEvents => _eventBus;
        public IEnumerable<ICommandHandler> Handlers => HandlersList;
        
        public CommandSequencer() : this(new EventBus(), new List<ICommandHandler>())
        {
            
        }

        public CommandSequencer(IEventBus eventBus, IEnumerable<ICommandHandler> handlers) : this(eventBus, new List<ICommandHandler>(handlers))
        {
            
        }

        public CommandSequencer(IEventBus eventBus, IList<ICommandHandler> handlers)
        {
            _eventBus = eventBus;
            HandlersList = new List<ICommandHandler>(handlers);
        }
        
        public void Update()
        {
            foreach (ICommandHandler handler in HandlersList)
            {
                foreach (ICommandStatus status in handler.UpdateCommands())
                {
                    _eventBus.Publish(new CommandUpdatedEvent(status));
                }
            }
        }
        
        public ICommandStatus IssueCommand(ICommand command)
        {
            foreach (var handler in Handlers)
            {
                if (handler.CanDoCommand(command))
                {
                    ICommandStatus status =  handler.DoCommand(command);
                    _eventBus.Publish(new CommandIssuedEvent(status));

                    return status;
                }
            }

            return new CommandStatus(Status.Failed, command, null);
        }
    }
}