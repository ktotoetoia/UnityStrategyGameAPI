using TDS.Factions;

namespace TDS.VisionSystem
{
    public interface IVision
    {
        public IFactionVision GetVision(IFaction faction);
    }
}