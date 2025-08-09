using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public interface IGameStage : ITurnUserManual
    {
        public ITurnCommandSequencer CommandSequencer { get; }
    }
}