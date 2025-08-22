using TDS.Components;

namespace TDS.Factions
{
    public interface IFactionComponent : IComponent,IHaveFaction
    {
        void SetFaction(IFaction faction);
    }
}