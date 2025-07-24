using TDS;
using TDS.Events;
using TDS.TurnSystem;
using TDS.Worlds;

namespace BuildingsTestGame
{
    public class BuildingGame : ITurnBasedGame
    {
        public IWorld World { get; }
        public IEventBus WorldEventBus { get; }
        public ITurnSwitcher TurnSwitcher { get; }
        public IGameStage AssignStage { get; }
        public IGameStage BuildStage { get; }
        public IGameStage EventStage  { get; }
        public IGameStage CurrentStage => TurnSwitcher.CurrentUser as IGameStage;
        
        public BuildingGame(IWorld world, IEventBus bus) : this(world,bus, new LegacyInputStagesFactory())
        {
            
        }

        public BuildingGame(IWorld world,IEventBus worldEventBus, IFactory<(GameStage,GameStage,GameStage),IWorld> GameStagesFactory)
        {
            World = world;
            WorldEventBus = worldEventBus;
            
            (GameStage, GameStage, GameStage) a = GameStagesFactory.Create(world);
            
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