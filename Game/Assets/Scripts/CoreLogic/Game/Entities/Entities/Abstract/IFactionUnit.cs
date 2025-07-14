using TDS.Factions;

namespace TDS.Entities
{
    public interface IFactionUnit : IUnit
    {
        public IFaction Faction { get; }
    }
}