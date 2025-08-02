using System.Collections.Generic;
using TDS.Handlers;

namespace TDS.Commands
{
    public interface ICommandSequencer
    {
        IEnumerable<IHandler<ICommand>> Handlers { get; }
        void IssueCommand(ICommand command);
    }
}