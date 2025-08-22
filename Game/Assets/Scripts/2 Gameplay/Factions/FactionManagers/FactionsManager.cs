using System.Collections.Generic;

namespace TDS.Factions
{
    public class FactionsManager : IFactionsManager
    {
        private readonly List<IFactionContext> _factionContexts = new();
        public ICollection<IFactionContext> FactionContexts => _factionContexts;
    }
}