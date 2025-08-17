using TDS;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class FirstBuildingFactory : IFactory<IBuilder<FirstBuilding>>
    {
        private readonly IHaveEntityRegistry _source;
        
        public IEntityRegistry  EntityRegistry { get; set; }
        
        public FirstBuildingFactory(IHaveEntityRegistry source)
        {
            _source = source;
        }
        
        public FirstBuildingFactory(IEntityRegistry entityRegistry)
        {
            EntityRegistry = entityRegistry;
        }
        
        public IBuilder<FirstBuilding> Create()
        {
            return new EntityBuilder<FirstBuilding>(new FirstBuilding(), EntityRegistry?? _source.EntityRegistry);
        }
    }
}