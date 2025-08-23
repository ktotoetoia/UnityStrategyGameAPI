using TDS.Components;
using TDS.Economy;

namespace BuildingsTestGame
{
    public interface IActionDoer : IComponent
    {
        ICappedValue<float> ActionPoints { get; }
    }
}