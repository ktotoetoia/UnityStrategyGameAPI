using TDS;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class DefaultUnitFactory : IFactory<DefaultUnit>
    {
        public IEntityRegistry  EntityRegistry { get; set; }
        
        public DefaultUnitFactory(IEntityRegistry entityRegistry)
        {
            EntityRegistry = entityRegistry;
        }
        
        public DefaultUnit Create()
        {
            DefaultUnit unit = new DefaultUnit();
            
            EntityRegistry.AddEntity(unit);

            return unit;
        }
    }
}