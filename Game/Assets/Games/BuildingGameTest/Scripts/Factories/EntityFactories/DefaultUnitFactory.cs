using TDS;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class DefaultUnitFactory : IFactory<IBuilder<DefaultUnit>>
    {
        public IHaveEntityRegister  Source { get; set; }
        
        public DefaultUnitFactory(IHaveEntityRegister source)
        {
            Source = source;
        }
        
        public IBuilder<DefaultUnit> Create()
        {
            return new EntityBuilder<DefaultUnit>(new DefaultUnit(), Source.EntityRegister);
        }
    }
}