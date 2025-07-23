using TDS.Commands;
using TDS.Entities;
using TDS.Worlds;

namespace BuildingsTestGame
{
    public class MoveUnitCommand : IEvent
    {
        public IUnit Unit { get;}
        public IPath<ITerrain> Path { get;}
     
        public MoveUnitCommand(IUnit Unit,IPath<ITerrain> Path)
        {
            this.Unit = Unit;
            this.Path = Path;
        }
    }
}