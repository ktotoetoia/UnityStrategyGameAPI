using System.Linq;
using TDS.Worlds;

namespace TDS.TurnSystem
{
    public class TurnBasedGame : ITurnBasedGame
    {
        public IWorld World { get; }
        public ITurnSwitcher TurnSwitcher { get; }
        
        public TurnBasedGame(IWorld world, ITurnSwitcher turnSwitcher)
        {
            World = world;
            TurnSwitcher = turnSwitcher;
        }

        public void Update()
        {
            TurnSwitcher.Update();
        }
    }
}