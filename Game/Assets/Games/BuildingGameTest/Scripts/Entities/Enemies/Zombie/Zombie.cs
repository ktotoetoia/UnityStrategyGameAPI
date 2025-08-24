using TDS.Components;
using TDS.Entities;
using TDS.Factions;

namespace BuildingsTestGame
{
    public class Zombie : DefaultUnit
    {
        public Zombie(float health = 100, float damage = 10) : base(health, damage)
        {
            Name = "Zombie";
            AddComponent(new ZombieComponent());
        }
    }
}