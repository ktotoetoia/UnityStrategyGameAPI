namespace TDS.Commands
{
    public class Command : ICommand
    {
        public Status Status { get; protected set; }
        
        public virtual void Finish(Status status)
        {
            Status = status;
        }
    }
}