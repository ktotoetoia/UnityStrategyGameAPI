using TDS;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class BuilderFactory : IFactory<IBuilder<Builder>>
    {
        public IHaveEntityRegistry  Source { get; set; }
        
        public BuilderFactory(IHaveEntityRegistry source)
        {
            Source = source;
        }
        
        public IBuilder<Builder> Create()
        {
            return new EntityBuilder<Builder>(new Builder(), Source.EntityRegistry);
        }
    }
}