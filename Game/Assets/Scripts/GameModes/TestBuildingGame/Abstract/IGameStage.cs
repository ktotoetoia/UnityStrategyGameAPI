using TDS;
using TDS.Commands;
using TDS.Events;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public interface IGameStage : ITurnUserManual, IUpdatable
    {
        public ICommandSequencer CommandSequencer { get; }
        public IInputHandler InputHandler { get; }
    }
}