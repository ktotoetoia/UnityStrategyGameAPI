using TDS;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class BuilderFactory : IFactory<IBuilder<Builder>>
    {
        public IEntityRegistry  EntityRegistry { get; set; }
        
        public BuilderFactory(IEntityRegistry entityRegistry)
        {
            EntityRegistry = entityRegistry;
        }
        
        public IBuilder<Builder> Create()
        {
            return new EntityBuilder<Builder>(new Builder(), EntityRegistry);
        }
    }
}