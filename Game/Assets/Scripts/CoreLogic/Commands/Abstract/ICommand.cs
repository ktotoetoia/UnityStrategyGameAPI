namespace TDS.Commands
{
    public interface ICommand
    {
        CommandStatus Status { get; }
        void Finish(CommandStatus status);
    }
}