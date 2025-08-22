using System.Collections.Generic;
using TDS.Entities;

namespace TDS.Factions
{
    public interface IFactionContext : IHaveFaction
    {
        public IEnumerable<IEntity> Entities { get; }        
    }
}