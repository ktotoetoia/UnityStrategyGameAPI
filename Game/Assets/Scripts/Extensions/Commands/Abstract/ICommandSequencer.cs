using System.Collections.Generic;
using TDS.Events;
using TDS.Handlers;

namespace TDS.Commands
{
    public interface ICommandSequencer
    {
        IEventSubscriber CommandEvents { get; }
        IEnumerable<IHandler<ICommand>> Handlers { get; }
        void IssueCommand(ICommand command);
    }
}