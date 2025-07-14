using TDS.Factions;
using TDS.Worlds;

namespace TDS.VisionSystem
{
    public class Vision : IVision
    {
        private readonly IWorld _world;

        public Vision(IWorld world)
        {
            _world = world;
        }

        public IFactionVision GetVision(IFaction faction)
        {
            return new FactionVision(faction, _world.EntityRegister.Entities);
        }
    }
}