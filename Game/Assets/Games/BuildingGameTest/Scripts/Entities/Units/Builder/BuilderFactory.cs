using TDS;
using TDS.Entities;
using TDS.Factions;

namespace BuildingsTestGame
{
    public class BuilderFactory : IFactory<Builder>
    {
        public IEntityRegistry  EntityRegistry { get; set; }
        public IFaction Faction { get; set; }
        
        public BuilderFactory(IEntityRegistry entityRegistry, IFaction faction)
        {
            EntityRegistry = entityRegistry;
            Faction = faction;
        }
        
        public Builder Create()
        {
            Builder builder = new Builder();
            
            builder.GetComponent<IFactionComponent>().SetFaction(Faction);
            EntityRegistry.AddEntity(builder);
            
            return builder;
        }
    }
}