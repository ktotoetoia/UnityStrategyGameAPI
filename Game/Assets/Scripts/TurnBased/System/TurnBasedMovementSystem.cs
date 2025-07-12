using TDS.Entities;
using TDS.Worlds;
using UnityEngine;

namespace TDS.TurnSystem
{
    public class TurnBasedMovementSystem : Systems.ISystem
    {
        public void Move(IFactionUnit unit, Vector3 position)
        {
            if (unit is not ITurnBasedFactionUnit u)
            {
                throw new System.Exception();
            }
            
            Move(u, position);
        }

        public void Move(ITurnBasedFactionUnit unit, Vector3 position)
        {
            var distance = Vector3.Distance(position, unit.Transform.Position);

            if (distance <= unit.Movement.AvailableTravelDistance)
            {
                unit.Movement.MoveTo(position);
            }
        }

        public IArea GetMovementArea(ITurnBasedFactionUnit unit)
        {
            return new CircleArea(unit.Transform.Position, unit.Movement.AvailableTravelDistance);
        }
    }
}