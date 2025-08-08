using TDS.Commands;
using TDS.Entities;
using TDS.Maps;

namespace BuildingsTestGame
{
    public class MoveUnitCommand : Command
    {
        public IEntity Unit { get;}
        public IMapPathfinder Pathfinder { get;}
        public IGameTerrain TargetTerrain { get;}
     
        public MoveUnitCommand(IEntity unit, IGameTerrain targetTerrain, IMapPathfinder pathfinder)
        {
            Unit = unit;
            Pathfinder = pathfinder;
            TargetTerrain = targetTerrain;
        }
    }
}