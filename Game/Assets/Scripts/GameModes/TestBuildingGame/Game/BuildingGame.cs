using TDS;
using TDS.TurnSystem;
using TDS.Worlds;

namespace BuildingsTestGame
{
    public class BuildingGame : ITurnBasedGame
    {
        public IBuildingGameContext GameContext { get; }
        public IWorld World { get; }
        public ITurnSwitcher TurnSwitcher { get; }
        public IGameStage AssignStage => GameContext.AssignStage;
        public IGameStage BuildStage => GameContext.BuildStage;
        public IGameStage EventStage => GameContext.EventStage;
        public IGameStage CurrentStage => TurnSwitcher.CurrentUser as IGameStage;
        
        public BuildingGame(IWorld world) : this(world, new LegacyInputGameContextFactory())
        {
            
        }

        public BuildingGame(IWorld world, IFactory<IBuildingGameContext,IWorld> GameContextFactory)
        {
            World = world;
            GameContext = GameContextFactory.Create(world);
            TurnSwitcher = new TurnSwitcher(new ITurnUser[] { AssignStage, BuildStage, EventStage });
        }
        
        public void Update()
        {
            GameContext.Update();
            TurnSwitcher.Update();
            CurrentStage.Update();
        }
    }
}