using TDS.Components;

namespace BuildingsTestGame
{
    public interface IActionDoer : IComponent
    {
        float MaxActionPoints { get; set; }
        float AvailableActionPoints { get; set; }
    }
}