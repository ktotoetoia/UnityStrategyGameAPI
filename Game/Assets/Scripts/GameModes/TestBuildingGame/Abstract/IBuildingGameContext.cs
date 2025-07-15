using TDS;
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
        public IGameStage CurrentStage { get; set; }
        public ISelector Selector { get; }
    }
}