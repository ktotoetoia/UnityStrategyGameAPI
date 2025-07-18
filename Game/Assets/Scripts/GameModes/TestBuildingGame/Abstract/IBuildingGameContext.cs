using TDS;
using TDS.Pathfinding;
using TDS.SelectionSystem;
using TDS.Worlds;

namespace BuildingsTestGame
{
    public interface IBuildingGameContext : IUpdatable
    {
        public IWorld World { get; }
        public IGameStage AssignStage { get; }
        public IGameStage BuildStage { get; }
        public IGameStage EventStage { get; }
        public ISelector Selector { get; }
        public IPathfinder Pathfinder { get; }
    }
}