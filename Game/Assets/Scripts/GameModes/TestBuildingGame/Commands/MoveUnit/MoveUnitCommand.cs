using TDS.Commands;
using TDS.Entities;
using TDS.Maps;

namespace BuildingsTestGame
{
    public class MoveUnitCommand : Command
    {
        public IEntity Unit { get;}
        public IPath<ITerrain> Path { get;}
     
        public MoveUnitCommand(IEntity Unit,IPath<ITerrain> Path)
        {
            this.Unit = Unit;
            this.Path = Path;
        }
    }
}