using TDS.Components;
using TDS.Events;

namespace TDS.Factions
{
    public class FactionComponent : Component,IFactionComponent
    {
        [BackingProperty(nameof(Faction))] private readonly ICallPropertyChange<IFaction> _faction;

        public IFaction Faction
        {
            get => _faction.Value;
            set => _faction.Value = value;
        }

        public FactionComponent()
        {
            _faction = new CallPropertyChange<IFaction>(this);
        }
        
        public FactionComponent(IFaction faction)
        {
            _faction = new CallPropertyChange<IFaction>(this);
            Faction = faction;
        }

        public void SetFaction(IFaction faction)
        {
            Faction = faction;
        }
    }
}