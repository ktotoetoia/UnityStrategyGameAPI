namespace TDS.Commands
{
    public interface ICommandStatus
    {
        Status Status { get; }
        ICommand Command { get; }
        ICommandHandler  Handler { get; }
    }
}