using TDS.Components;
using TDS.Damage;
using TDS.Entities;
using TDS.Factions;

namespace BuildingsTestGame
{
    public class DefaultUnit : Entity
    {
        public DefaultUnit(float health = 100, float damage = 10)
        {
            Name = "Default Unit";
            AddComponent(new EventComponent());
            AddComponent(new ActionDoer());
            AddComponent(new UnitMovementOnTerrain());
            AddComponent(new FactionComponent());
            AddComponent(new FloatDamageDealerComponent(damage));
            AddComponent(new FloatHealthComponent(health));
        }
    }
}