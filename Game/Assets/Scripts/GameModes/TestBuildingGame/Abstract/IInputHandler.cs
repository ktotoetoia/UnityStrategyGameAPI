using TDS.Events;

namespace BuildingsTestGame
{
    public interface IInputHandler
    {
        public void HandleInput(IEventBus queue);
    }
}