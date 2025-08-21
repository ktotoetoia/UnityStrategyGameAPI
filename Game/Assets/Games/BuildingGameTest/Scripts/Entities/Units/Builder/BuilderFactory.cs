using TDS;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class BuilderFactory : IFactory<Builder>
    {
        public IEntityRegistry  EntityRegistry { get; set; }
        
        public BuilderFactory(IEntityRegistry entityRegistry)
        {
            EntityRegistry = entityRegistry;
        }
        
        public Builder Create()
        {
            Builder builder = new Builder();
            
            EntityRegistry.AddEntity(builder);
            
            return builder;
        }
    }
}