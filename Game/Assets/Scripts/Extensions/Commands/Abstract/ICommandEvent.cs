using TDS.Events;

namespace TDS.Commands
{
    public interface ICommandEvent<T> : IEvent where T : ICommand
    {
        T Command { get; set; }
    }
}