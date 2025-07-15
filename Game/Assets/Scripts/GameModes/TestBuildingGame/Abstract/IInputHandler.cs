using TDS.Commands;

namespace BuildingsTestGame
{
    public interface IInputHandler
    {
        public void HandleInput(ICommandHandler handler);
    }
}