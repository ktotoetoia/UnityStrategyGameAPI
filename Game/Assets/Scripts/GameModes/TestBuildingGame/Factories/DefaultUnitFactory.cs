using TDS;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class DefaultUnitFactory : IFactory<DefaultUnit>
    {
        public IEntityRegister  EntityRegister { get; set; }

        public DefaultUnitFactory(IEntityRegister entityRegister)
        {
            EntityRegister = entityRegister;
        }
        
        public DefaultUnit Create()
        {
            DefaultUnit unit = new DefaultUnit();
            
            EntityRegister.AddEntity(unit);

            return unit;
        }
    }
}