using TDS;
using TDS.Entities;
using TDS.Factions;

namespace BuildingsTestGame
{
    public class DefaultUnitFactory : IFactory<DefaultUnit>
    {
        public IEntityRegistry  EntityRegistry { get; set; }
        public IFaction Faction { get; set; }
        
        public DefaultUnitFactory(IEntityRegistry entityRegistry, IFaction faction)
        {
            EntityRegistry = entityRegistry;
            Faction = faction;
        }
        
        public DefaultUnit Create()
        {
            DefaultUnit unit = new DefaultUnit();
            
            unit.GetComponent<IFactionComponent>().SetFaction(Faction);
            EntityRegistry.AddEntity(unit);

            return unit;
        }
    }
}