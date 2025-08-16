using TDS;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class FirstBuildingFactory : IFactory<IBuilder<FirstBuilding>>
    {
        private readonly IHaveEntityRegister _source;
        
        public IEntityRegister  EntityRegister { get; set; }
        
        public FirstBuildingFactory(IHaveEntityRegister source)
        {
            _source = source;
        }
        
        public FirstBuildingFactory(IEntityRegister entityRegister)
        {
            EntityRegister = entityRegister;
        }
        
        public IBuilder<FirstBuilding> Create()
        {
            return new EntityBuilder<FirstBuilding>(new FirstBuilding(), EntityRegister?? _source.EntityRegister);
        }
    }
}