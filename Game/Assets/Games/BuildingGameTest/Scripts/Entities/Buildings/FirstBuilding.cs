using TDS.Entities;

namespace BuildingsTestGame
{
    public class FirstBuilding : Entity
    {
        public FirstBuilding()
        {
            AddComponent(new EventComponent());
            AddComponent(new BuildingOnTerrain());
            AddComponent(new BuildingComponent());
        }
    }
}