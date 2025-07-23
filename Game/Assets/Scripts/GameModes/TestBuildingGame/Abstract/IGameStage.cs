using TDS;
using TDS.Commands;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public interface IGameStage : ITurnUserManual, IUpdatable
    {
        public IEventBus EventBus { get; }
        public IInputHandler InputHandler { get; }
    }
}