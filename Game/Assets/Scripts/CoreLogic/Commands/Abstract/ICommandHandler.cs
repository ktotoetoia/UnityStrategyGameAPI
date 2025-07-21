namespace TDS.Commands
{
    public interface ICommandHandler
    {
        bool CanDoCommand(ICommand command);
        void DoCommand(ICommand command);
    }
}