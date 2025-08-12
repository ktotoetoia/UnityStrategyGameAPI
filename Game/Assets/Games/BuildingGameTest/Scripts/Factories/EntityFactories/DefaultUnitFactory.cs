using TDS;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class DefaultUnitFactory : IFactory<IBuilder<DefaultUnit>>
    {
        public IEntityRegister  EntityRegister { get; set; }
        
        public DefaultUnitFactory(IEntityRegister entityRegister)
        {
            EntityRegister = entityRegister;
        }
        
        public IBuilder<DefaultUnit> Create()
        {
            return new EntityBuilder<DefaultUnit>(new DefaultUnit(), EntityRegister);
        }
    }
}