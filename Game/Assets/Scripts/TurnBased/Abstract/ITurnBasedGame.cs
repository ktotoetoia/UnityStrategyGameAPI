using TDS.Worlds;

namespace TDS.TurnSystem
{
    public interface ITurnBasedGame : IUpdatable
    {
        public IWorld World { get; }
        public ITurnSwitcher TurnSwitcher { get; }
    }
}