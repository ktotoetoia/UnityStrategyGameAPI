using System.Collections.Generic;
using System.Linq;
using TDS.Entities;

namespace TDS.Factions
{
    public class FactionContext : IFactionContext
    {
        private readonly IEntityRegistry _entityRegistry;
        public IEnumerable<IEntity> Entities => _entityRegistry.Where(x => x.TryGetComponent(out IFactionComponent fc) && fc.Faction == Faction);
        public IFaction Faction { get; }
        
        public FactionContext(IFaction faction, IEntityRegistry entityRegistry)
        {
            _entityRegistry = entityRegistry;
            Faction = faction;
        }
    }
}