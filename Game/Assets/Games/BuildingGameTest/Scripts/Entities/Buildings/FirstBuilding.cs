using TDS.Entities;

namespace BuildingsTestGame
{
    public class FirstBuilding : Entity
    {
        public IEntityInitializer EntityInitializer { get; }

        public FirstBuilding(IEntityInitializer entityInitializer)
        {
            EntityInitializer = entityInitializer;
            AddComponent(new EventComponent());
            AddComponent(new MovementOnTerrain());
            AddComponent(new BuildingComponent());
        }
    }
}