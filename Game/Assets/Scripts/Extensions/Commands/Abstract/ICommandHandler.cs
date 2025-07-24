using System.Collections.Generic;

namespace TDS.Commands
{
    public interface ICommandHandler
    {
        bool CanDoCommand(ICommand command);
        ICommandStatus DoCommand(ICommand command);
        
        IEnumerable<ICommandStatus> UpdateCommands();
    }
}