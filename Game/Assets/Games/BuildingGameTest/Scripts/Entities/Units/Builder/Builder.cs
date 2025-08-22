using TDS.Components;
using TDS.Entities;
using TDS.Factions;

namespace BuildingsTestGame
{
    public class Builder : Entity
    {
        public Builder()
        {
            Name = "Builder";
            AddComponent(new EventComponent());
            AddComponent(new ActionDoer());
            AddComponent(new UnitMovementOnTerrain());
            AddComponent(new BuilderComponent());
            AddComponent(new FactionComponent());
        }
    }
}