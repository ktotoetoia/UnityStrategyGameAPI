using TDS.Components;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public class ActionDoer : Component, IActionDoer, INotifyOnTurnStart
    {
        public float MaxActionPoints { get; set; } = 3;
        public float AvailableActionPoints { get; set; } = 3;
        
        public void OnTurnStart()
        {
            AvailableActionPoints = MaxActionPoints;
        }
    }
}