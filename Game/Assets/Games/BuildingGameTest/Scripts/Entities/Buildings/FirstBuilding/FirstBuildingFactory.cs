using TDS;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class FirstBuildingFactory : IFactory<FirstBuilding>
    {
        public IEntityRegistry  EntityRegistry { get; set; }
        
        public FirstBuildingFactory(IEntityRegistry entityRegistry)
        {
            EntityRegistry = entityRegistry;
        }
        
        public FirstBuilding Create()
        {
            FirstBuilding building = new FirstBuilding();
            
            EntityRegistry.AddEntity(building);
            
            return building;
        }
    }
}