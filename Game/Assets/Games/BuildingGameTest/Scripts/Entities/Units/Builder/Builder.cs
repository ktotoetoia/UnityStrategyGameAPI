using TDS.Components;
using TDS.Entities;
using TDS.Factions;

namespace BuildingsTestGame
{
    public class Builder : DefaultUnit
    {
        public Builder(float health = 100, float damage = 5) : base(health, damage)
        {
            Name = "Builder";
            AddComponent(new BuilderComponent());
        }
    }
}