using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDS.Factions;
using TDS.Systems;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TDS.TurnSystem
{
    public class AITurnLogic : ITurnUser, ISystemUser
    {
        private readonly IFaction _faction;
        private UnitCreationSystem _unitCreationSystem;
        
        public AITurnLogic(IFaction faction)
        {
            _faction = faction;
        }

        public async ValueTask ExecuteTurnAsync()
        {
            Debug.Log($"{_faction.Name} is thinking...");
            await Task.Delay(4000);

            _unitCreationSystem?.CreateUnit(_faction, Random.insideUnitCircle * 4);

            Debug.Log($"{_faction.Name} ends their turn.");
        }

        public IEnumerable<Type> GetRequiredSystems()
        {
            return new [] { typeof(UnitCreationSystem) };
        }

        public void Inject(IEnumerable<ISystem> systems)
        {
            _unitCreationSystem = systems.OfType<UnitCreationSystem>().FirstOrDefault();
        }
    }
}