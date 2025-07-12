using TDS.Entities;
using TDS.Factions;

namespace TDS.TurnSystem
{
    public sealed class TurnBasedFactionUnit : FactionUnit, ITurnBasedFactionUnit
    {
        public TurnBasedFactionUnit(IFaction faction) :this("default", faction)
        {
            
        }
        
        public TurnBasedFactionUnit(string name, IFaction faction) : base(name, faction)
        {
            Movement = new TurnBasedMovementComponent
            {
                MaxTravelDistancePerTurn = 4
            };

            AddComponent(Movement);
        }

        public TurnBasedMovementComponent Movement { get; }

        public void OnTurnStart()
        {
            foreach (var component in _components)
                if (component is ITurnObject turnBasedComponent)
                    turnBasedComponent.OnTurnStart();
        }

        public void OnTurnEnd()
        {
            foreach (var component in _components)
                if (component is ITurnObject turnBasedComponent)
                    turnBasedComponent.OnTurnEnd();
        }
    }
}