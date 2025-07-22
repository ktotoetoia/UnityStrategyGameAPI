using TDS;
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
        public IGameStage EventStage  { get; }
        public IGameStage CurrentStage => TurnSwitcher.CurrentUser as IGameStage;
        
        public BuildingGame(IWorld world) : this(world, new LegacyInputGameContextFactory())
        {
            
        }

        public BuildingGame(IWorld world, IFactory<(GameStage,GameStage,GameStage),IWorld> GameContextFactory)
        {
            World = world;
            var a =GameContextFactory.Create(world);
            AssignStage = a.Item1;
            BuildStage = a.Item2;
            EventStage = a.Item3;
            
            TurnSwitcher = new TurnSwitcher(new ITurnUser[] { AssignStage, BuildStage, EventStage });
        }
        
        public void Update()
        {
            TurnSwitcher.Update();
            CurrentStage.Update();
        }
    }
}