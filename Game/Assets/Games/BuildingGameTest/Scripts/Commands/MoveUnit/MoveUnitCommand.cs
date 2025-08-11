using TDS.Entities;
using TDS.Maps;

namespace BuildingsTestGame
{
    public class MoveUnitCommand
    {
        public IEntity Unit { get;}
        public IMapPathfinder Pathfinder { get;}
        public ITerrainArea TargetTerrain { get;}
     
        public MoveUnitCommand(IEntity unit, ITerrainArea targetTerrain, IMapPathfinder pathfinder)
        {
            Unit = unit;
            Pathfinder = pathfinder;
            TargetTerrain = targetTerrain;
        }
    }
}