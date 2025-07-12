using System;
using System.Collections.Generic;
using TDS.Systems;
using TDS.TurnSystem;
using TDS.Worlds;
using TDS.VisionSystem;
using Unity.VisualScripting;

namespace TDS
{
    public class GameFactory : IFactory<TurnBasedGame, IWorld>
    {
        public TurnBasedGame Create(IWorld world)
        {
            var participants = new List<ITurnUser>();
            SystemManager manager = new SystemManager();
            
            manager.Systems.Add(new UnitCreationSystem(world,new TurnBasedFactionUnitFactory()));
            manager.Systems.Add(new TurnBasedMovementSystem());
            manager.Systems.Add(new FightSystem(world));

            throw new SystemException();
            /*
             
            foreach (var faction in world.Factions)
            {
                if (participants.Count == 0)
                {
                    participants.Add(new PlayerTurnLogic(faction, world));

                    continue;
                }

                participants.Add(new AITurnLogic(faction));
            }
             */

            var turnSwitcher = new TurnSwitcher(participants);

            return new TurnBasedGame(world, turnSwitcher, manager);
        }
    }
}