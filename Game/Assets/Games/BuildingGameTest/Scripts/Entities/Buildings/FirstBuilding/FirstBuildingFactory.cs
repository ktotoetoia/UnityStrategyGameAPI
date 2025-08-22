using TDS;
using TDS.Entities;
using TDS.Factions;

namespace BuildingsTestGame
{
    public class FirstBuildingFactory : IFactory<FirstBuilding>
    {
        public IEntityRegistry  EntityRegistry { get; set; }
        public IFaction Faction { get; set; }
        
        public FirstBuildingFactory(IEntityRegistry entityRegistry, IFaction faction)
        {
            Faction = faction;
            EntityRegistry = entityRegistry;
        }
        
        public FirstBuilding Create()
        {
            FirstBuilding building = new FirstBuilding();
            
            building.GetComponent<IFactionComponent>().SetFaction(Faction);
            EntityRegistry.AddEntity(building);
            
            return building;
        }
    }
}