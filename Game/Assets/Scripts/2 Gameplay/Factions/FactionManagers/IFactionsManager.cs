using System.Collections.Generic;

namespace TDS.Factions
{
    public interface IFactionsManager
    {
        ICollection<IFactionContext> FactionContexts { get; }
    }
}