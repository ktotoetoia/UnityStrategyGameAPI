using TDS;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class BuilderFactory : IFactory<IBuilder<Builder>>
    {
        public IHaveEntityRegister  Source { get; set; }
        
        public BuilderFactory(IHaveEntityRegister source)
        {
            Source = source;
        }
        
        public IBuilder<Builder> Create()
        {
            return new EntityBuilder<Builder>(new Builder(), Source.EntityRegister);
        }
    }
}