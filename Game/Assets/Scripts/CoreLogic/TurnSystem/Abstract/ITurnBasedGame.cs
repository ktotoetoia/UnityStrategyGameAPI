using TDS.Entities;
using TDS.Maps;

namespace TDS.TurnSystem
{
    public interface ITurnBasedGame
    {
        public IEntityRegister EntityRegister { get; }
        public IMap Map { get; }
        public ITurnSwitcher TurnSwitcher { get; }
    }
}