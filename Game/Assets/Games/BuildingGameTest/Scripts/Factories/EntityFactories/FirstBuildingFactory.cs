using TDS;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class FirstBuildingFactory : IFactory<IBuilder<FirstBuilding>>
    {
        public IEntityRegister  EntityRegister { get; set; }

        public FirstBuildingFactory(IEntityRegister entityRegister)
        {
            EntityRegister = entityRegister;
        }
        
        public IBuilder<FirstBuilding> Create()
        {
            return new EntityBuilder<FirstBuilding>(new FirstBuilding(), EntityRegister);
        }
    }
}