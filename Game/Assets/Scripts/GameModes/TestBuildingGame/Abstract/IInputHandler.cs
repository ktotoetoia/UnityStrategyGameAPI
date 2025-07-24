using TDS.Commands;
using TDS.Events;

namespace BuildingsTestGame
{
    public interface IInputHandler
    {
        public void HandleInput(ICommandSequencer sequencer);
    }
}