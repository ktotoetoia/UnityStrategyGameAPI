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
        public ISubscriber MapEvents { get; }
        public ITurnSwitcher TurnSwitcher { get; }
        public IGameStage AssignStage { get; }
        public IGameStage BuildStage { get; }
        public IGameStage EventStage  { get; }
        public IGameStage CurrentStage => TurnSwitcher.CurrentUser as IGameStage;
        
        public BuildingGame(IMap map, ISubscriber bus) : this(map,bus, new StagesFactory())
        {
            
        }

        public BuildingGame(IMap map,ISubscriber mapEvents, IFactory<(GameStage,GameStage,GameStage)> GameStagesFactory)
        {
            Map = map;
            MapEvents = mapEvents;
            EntityRegister register = new EntityRegister();
            EntityRegister = register;
            EntityRegisterEvents = new EntityRegisterEvents(register);
            (AssignStage, BuildStage, EventStage) = GameStagesFactory.Create();

            TurnSwitcher = new TurnSwitcher(new ITurnUser[] { AssignStage, BuildStage, EventStage });
        }
        
        public void Update()
        {
            TurnSwitcher.Update();
        }
    }
}