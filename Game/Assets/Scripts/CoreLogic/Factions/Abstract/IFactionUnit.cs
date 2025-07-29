using TDS.Factions;

namespace TDS.Entities
{
    public interface IFactionUnit : IEntity
    {
        public IFaction Faction { get; }
    }
}