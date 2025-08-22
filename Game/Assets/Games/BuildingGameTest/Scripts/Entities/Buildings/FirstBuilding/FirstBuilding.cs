using TDS.Components;
using TDS.Entities;
using TDS.Factions;

namespace BuildingsTestGame
{
    public class FirstBuilding : Entity
    {
        public FirstBuilding()
        {
            Name = "First Building";
            AddComponent(new EventComponent());
            AddComponent(new BuildingOnTerrain());
            AddComponent(new UnitCreationComponent());
            AddComponent(new FactionComponent());
        }
    }
}