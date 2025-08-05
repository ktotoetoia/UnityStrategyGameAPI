using TDS;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class FirstBuildingFactory : IFactory<FirstBuilding>
    {
        public IEntityRegister  EntityRegister { get; set; }

        public FirstBuildingFactory(IEntityRegister entityRegister)
        {
            EntityRegister = entityRegister;
        }
        
        public FirstBuilding Create()
        {
            FirstBuilding building = new FirstBuilding(new EventEntityInitializer());
            
            EntityRegister.AddEntity(building);

            return building;
        }
    }
}