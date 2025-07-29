namespace TDS.Commands
{
    public class CommandEvent<T> : ICommandEvent<T> where T : ICommand
    {
        public T Command { get; set; }
        
        public CommandEvent(T command)
        {
            Command = command;
        }
    }
}