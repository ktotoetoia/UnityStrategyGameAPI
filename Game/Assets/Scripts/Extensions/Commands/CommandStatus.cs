namespace TDS.Commands
{
    public class CommandStatus : ICommandStatus
    {
        public Status Status { get; }
        public ICommand Command { get;  }
        public ICommandHandler Handler { get; }

        public CommandStatus(Status status, ICommand command, ICommandHandler handler)
        {
            Status = status;
            Command = command;
            Handler = handler;
        }
    }
}