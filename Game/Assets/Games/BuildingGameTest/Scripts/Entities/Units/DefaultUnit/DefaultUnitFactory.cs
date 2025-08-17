using TDS;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class DefaultUnitFactory : IFactory<IBuilder<DefaultUnit>>
    {
        public IHaveEntityRegistry  Source { get; set; }
        
        public DefaultUnitFactory(IHaveEntityRegistry source)
        {
            Source = source;
        }
        
        public IBuilder<DefaultUnit> Create()
        {
            return new EntityBuilder<DefaultUnit>(new DefaultUnit(), Source.EntityRegistry);
        }
    }
}