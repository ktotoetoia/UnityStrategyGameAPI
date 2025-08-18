using TDS;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class FirstBuildingFactory : IFactory<IBuilder<FirstBuilding>>
    {
        public IEntityRegistry  EntityRegistry { get; set; }
        
        public FirstBuildingFactory(IEntityRegistry entityRegistry)
        {
            EntityRegistry = entityRegistry;
        }
        
        public IBuilder<FirstBuilding> Create()
        {
            return new EntityBuilder<FirstBuilding>(new FirstBuilding(), EntityRegistry);
        }
    }
}