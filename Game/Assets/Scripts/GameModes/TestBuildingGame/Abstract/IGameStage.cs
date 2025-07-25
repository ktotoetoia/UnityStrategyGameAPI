using TDS;
using TDS.Commands;
using TDS.Events;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public interface IGameStage : ITurnUserManual
    {
        public ICommandSequencer CommandSequencer { get; }
    }
}