using System.Collections.Generic;
using TDS.Handlers;

namespace TDS.Commands
{
    public interface ICommandSequencer
    {
        IEnumerable<IConditionalHandler<ICommand>> Handlers { get; }
        void IssueCommand(ICommand command);
    }
}