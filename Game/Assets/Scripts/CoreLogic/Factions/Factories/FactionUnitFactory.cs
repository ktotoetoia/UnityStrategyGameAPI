using TDS.Factions;

namespace TDS.Entities
{
    public class FactionUnitFactory : IFactory<FactionUnit, string, IFaction>,IFactory<FactionUnit, IFaction>
    {
        public FactionUnit Create(string param1, IFaction param2)
        {
            return new FactionUnit(param1, param2);
        }
        
        public FactionUnit Create(IFaction param2)
        {
            return new FactionUnit(param2);
        }
    }
}