using TDS.Components;
using TDS.Economy;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public class ActionDoer : Component, IActionDoer, INotifyOnTurnStart
    {
        public ICappedValue<float> ActionPoints { get; } = new CappedValue<float>(0,3,3);

        public void OnTurnStart()
        {
            ActionPoints.Value = ActionPoints.MaxValue;
        }
    }
}