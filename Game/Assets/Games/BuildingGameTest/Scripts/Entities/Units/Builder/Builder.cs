using TDS.Entities;

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
        }
    }
}