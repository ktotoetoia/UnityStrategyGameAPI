using TDS;
using TDS.Events;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public interface IGameStage : ITurnUserManual, IUpdatable
    {
        public IEventBus EventBus { get; }
        public IInputHandler InputHandler { get; }
    }
}