using TDS.Factions;

namespace TDS.TurnSystem
{
    public class TurnBasedFactionUnitFactory : IFactory<TurnBasedFactionUnit, IFaction>
    {
        public TurnBasedFactionUnit Create(IFaction param2)
        {
            return new TurnBasedFactionUnit(param2);
        }
    }
}