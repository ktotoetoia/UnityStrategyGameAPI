using UnityEngine;
using Component = TDS.Components.Component;

namespace TDS.TurnSystem
{
    public class TurnBasedMovementComponent : Component, ITurnObject
    {
        public float MaxTravelDistancePerTurn { get; set; } = 4;
        public float AvailableTravelDistance { get; set; } = 4;

        public void OnTurnStart()
        {
            AvailableTravelDistance = MaxTravelDistancePerTurn;
        }

        public void OnTurnEnd()
        {
        }

        public void MoveTo(Vector3 position)
        {
            AvailableTravelDistance -= Vector2.Distance(position, Entity.Transform.Position);

            Entity.Transform.SetPosition(position);
        }
    }
}