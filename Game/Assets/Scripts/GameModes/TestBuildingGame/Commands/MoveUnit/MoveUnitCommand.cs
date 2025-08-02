using TDS.Commands;
using TDS.Maps;

namespace BuildingsTestGame
{
    public class MoveUnitCommand : Command
    {
        public IUnit Unit { get;}
        public IPath<ITerrain> Path { get;}
     
        public MoveUnitCommand(IUnit unit,IPath<ITerrain> path)
        {
            Unit = unit;
            Path = path;
        }
    }
}