using TDS.Events;

namespace TDS.Commands
{
    public class CommandIssuedEvent : IEvent
    {
        public ICommandStatus CommandStatus { get; }
        
        public CommandIssuedEvent(ICommandStatus commandStatus)
        {
            CommandStatus = commandStatus;
        }
    }
}