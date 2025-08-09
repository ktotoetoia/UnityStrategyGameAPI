using TDS;
using TDS.Entities;
using TDS.Events;
using TDS.Maps;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public class BuildingGame : ITurnBasedGame
    {
        public IMap Map { get; }
        public IEntityRegister EntityRegister { get; }
        public ISubscriber EntityRegisterEvents { get; }
        public ITurnSwitcher TurnSwitcher { get; }
        
        public IGameStage AssignStage { get; }
        public IGameStage BuildStage { get; }
        public IGameStage EventStage  { get; }
        public IGameStage CurrentStage => TurnSwitcher.CurrentUser as IGameStage;
        
        public BuildingGame(IMap map,IEntityRegister entityRegister, ISubscriber entityRegisterEvents) : this(map,entityRegister,entityRegisterEvents,new StagesFactory())
        {
            
        }

        public BuildingGame(IMap map,IEntityRegister entityRegister, ISubscriber entityRegisterEvents, IFactory<(GameStage,GameStage,GameStage)> GameStagesFactory)
        {
            Map = map;
            EntityRegister = entityRegister;
            EntityRegisterEvents = entityRegisterEvents;
            (AssignStage, BuildStage, EventStage) = GameStagesFactory.Create();

            TurnSwitcher = new TurnSwitcher(new ITurnUser[] { AssignStage, BuildStage, EventStage });
        }
        
        public void Update()
        {
            TurnSwitcher.Update();
        }
    }
}