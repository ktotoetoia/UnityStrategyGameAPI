using TDS.TurnSystem;
using TDS.Worlds;

namespace BuildingsTestGame
{
    public class BuildingGame : ITurnBasedGame
    {
        public IWorld World { get; }
        public ITurnSwitcher TurnSwitcher { get; }
        public IGameStage AssignStage { get; }
        public IGameStage BuildStage { get; }
        public IGameStage EventStage { get; }
        public IGameStage CurrentStage => TurnSwitcher.CurrentUser as IGameStage;
        
        public BuildingGame(IWorld world) : this(world, new LegacyInputStageFactory())
        {
            
        }

        public BuildingGame(IWorld world, IStageFactory stageFactory)
        {
            World = world;

            AssignStage = stageFactory.CreateAssignStage();
            BuildStage = stageFactory.CreateBuildStage();
            EventStage = stageFactory.CreateEventStage();
            
            TurnSwitcher = new TurnSwitcher(new ITurnUser[] {AssignStage, BuildStage, EventStage});
        }
        
        public void Update()
        {
            TurnSwitcher.Update();
            CurrentStage.Update();
            
        }
    }
}