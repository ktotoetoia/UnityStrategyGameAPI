using System.Linq;
using TDS.Systems;
using TDS.Worlds;

namespace TDS.TurnSystem
{
    public class TurnBasedGame : IUpdatable
    {
        public IWorld World { get; }
        public ITurnSwitcher TurnSwitcher { get; }
        public ISystemManager SystemManager { get; }
        
        public TurnBasedGame(IWorld world, ITurnSwitcher turnSwitcher, ISystemManager systemManager)
        {
            World = world;
            TurnSwitcher = turnSwitcher;
            SystemManager = systemManager;
            InjectSystems();
        }

        public void InjectSystems()
        {
            SystemManager.InjectAll(TurnSwitcher.Users.OfType<ISystemUser>());
        }

        public void Update()
        {
            TurnSwitcher.Update();
        }
    }
}