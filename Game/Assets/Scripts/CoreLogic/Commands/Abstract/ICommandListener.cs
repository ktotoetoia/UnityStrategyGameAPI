using System.Linq;

namespace TDS.Commands
{
    public interface ICommandListener
    {
        bool CanDoCommand(ICommand command);
        void DoCommand(ICommand command);
    }
}