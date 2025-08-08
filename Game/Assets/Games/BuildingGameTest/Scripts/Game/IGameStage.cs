using TDS.Commands;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public interface IGameStage : ITurnUserManual
    {
        public ICommandSequencer CommandSequencer { get; }
    }
}