using TDS.Entities;

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
        }
    }
}