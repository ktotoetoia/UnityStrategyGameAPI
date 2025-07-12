using TDS.Entities;
using TDS.Worlds;
using UnityEngine;

namespace TDS.Systems
{
    public class FightSystem : ISystem
    {
        private IWorld _world;

        public FightSystem(IWorld world)
        {
            _world = world;
        }
        
        public void Fight(IFactionUnit attacker, IFactionUnit target)
        {
            if (Random.Range(0, 1) == 1)
            {
                _world.EntityRegister.RemoveEntity(attacker);
                attacker.Destroy();
                
                return;
            }

            _world.EntityRegister.RemoveEntity(target);
            target.Destroy();
        }
    }
}