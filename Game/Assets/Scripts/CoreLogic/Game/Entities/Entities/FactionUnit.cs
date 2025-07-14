using TDS.Factions;

namespace TDS.Entities
{
    public class FactionUnit : Entity, IFactionUnit
    {
        public IFaction Faction { get; }
        
        public FactionUnit(IFaction faction) : this("default",faction)
        {
            
        }
        
        public FactionUnit(string name, IFaction faction)
        {
            Faction = faction;
            Name = name;
        }
    }
}