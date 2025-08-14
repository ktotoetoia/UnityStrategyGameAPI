using TDS.Entities;

namespace BuildingsTestGame
{
    public class FirstBuilding : Entity
    {
        public FirstBuilding()
        {
            Name = "First Building";
            AddComponent(new EventComponent());
            AddComponent(new BuildingOnTerrain());
            AddComponent(new UnitCreatingComponent());
        }
    }
}