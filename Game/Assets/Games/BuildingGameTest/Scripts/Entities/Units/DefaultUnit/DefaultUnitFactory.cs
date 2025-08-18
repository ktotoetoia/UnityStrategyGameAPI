using TDS;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class DefaultUnitFactory : IFactory<IBuilder<DefaultUnit>>
    {
        public IEntityRegistry  EntityRegistry { get; set; }
        
        public DefaultUnitFactory(IEntityRegistry entityRegistry)
        {
            EntityRegistry = entityRegistry;
        }
        
        public IBuilder<DefaultUnit> Create()
        {
            return new EntityBuilder<DefaultUnit>(new DefaultUnit(), EntityRegistry);
        }
    }
}