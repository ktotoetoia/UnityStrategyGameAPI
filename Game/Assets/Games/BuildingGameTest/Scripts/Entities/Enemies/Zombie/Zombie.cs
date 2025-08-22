using TDS.Components;
using TDS.Entities;
using TDS.Factions;

namespace BuildingsTestGame
{
    public class Zombie : Entity
    {
        public Zombie()
        {
            Name = "Zombie";
            AddComponent(new EventComponent());
            AddComponent(new ActionDoer());
            AddComponent(new UnitMovementOnTerrain());
            AddComponent(new ZombieComponent());
            AddComponent(new FactionComponent());
        }
    }
}