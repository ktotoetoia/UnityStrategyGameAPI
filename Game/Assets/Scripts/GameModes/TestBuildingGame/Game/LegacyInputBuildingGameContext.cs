using TDS.SelectionSystem;
using TDS.Worlds;
using UnityEngine;

namespace BuildingsTestGame
{
    public class LegacyInputBuildingGameContext : IBuildingGameContext
    {
        public IWorld World { get; set; }
        public IGameStage AssignStage { get; set; }
        public IGameStage BuildStage { get; set; }
        public IGameStage EventStage { get; set; }
        public ISelector Selector { get; set; }
        public IMapPathfinder Pathfinder { get; set; }
    }
}