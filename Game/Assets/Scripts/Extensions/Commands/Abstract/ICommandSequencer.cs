using System.Collections.Generic;
using TDS.Events;

namespace TDS.Commands
{
    public interface ICommandSequencer : IUpdatable
    {
        IEventSubscriber CommandEvents { get; }
        IEnumerable<ICommandHandler> Handlers { get; }
        
        ICommandStatus IssueCommand(ICommand command);
    }
}