using TDS.Commands;
using TDS.Events;

namespace BuildingsTestGame
{

    public interface ICommandEvent<T> : IEvent where T : ICommand
    {
        T Command { get; set; }
    }
}