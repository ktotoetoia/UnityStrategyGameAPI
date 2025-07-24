using TDS.Events;

namespace TDS.Commands
{
    public class CommandUpdatedEvent : IEvent
    {
        public ICommandStatus CommandStatus { get; }

        public CommandUpdatedEvent(ICommandStatus commandStatus)
        {
            CommandStatus = commandStatus;
        }
    }
}