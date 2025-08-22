using TDS.Components;
using TDS.Entities;
using TDS.Factions;

namespace BuildingsTestGame
{
    public class DefaultUnit : Entity
    {
        public DefaultUnit()
        {
            Name = "Default Unit";
            AddComponent(new EventComponent());
            AddComponent(new ActionDoer());
            AddComponent(new UnitMovementOnTerrain());
            AddComponent(new FactionComponent());
        }
    }
}