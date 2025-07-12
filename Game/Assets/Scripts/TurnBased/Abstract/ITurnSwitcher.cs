using System.Collections.Generic;

namespace TDS.TurnSystem
{
    public interface ITurnSwitcher : IUpdatable
    {
        public IEnumerable<ITurnUser> Users { get; }
        public ITurnUser CurrentUser { get; }
    }
}