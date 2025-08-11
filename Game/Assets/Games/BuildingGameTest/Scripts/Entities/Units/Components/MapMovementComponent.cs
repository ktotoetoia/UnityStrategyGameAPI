using TDS.Components;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public class MapMovementComponent : Component, IMapMovementComponent, ITurnObject
    {
        public float TotalMovementPoints { get; set; } = 123123123;
        public float AvailableMovementPoints { get; set; } = 123123123;
        
        public void OnTurnStart()
        {
            AvailableMovementPoints = TotalMovementPoints;
        }

        public void OnTurnEnd()
        {
            
        }
    }
}