namespace TDS.Commands
{
    public class Command : ICommand
    {
        public CommandStatus Status { get; protected set; }
        
        public virtual void Finish(CommandStatus status)
        {
            Status = status;
        }
    }
}