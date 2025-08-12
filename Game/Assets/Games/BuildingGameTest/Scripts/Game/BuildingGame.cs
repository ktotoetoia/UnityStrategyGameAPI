using TDS.Entities;
using TDS.Events;
using TDS.Maps;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public class BuildingGame
    {
        public IGraphMap Map { get; }
        public IEntityRegister EntityRegister { get; }
        public ISubscriber EntityRegisterEvents { get; }
        public ITurnSwitcher TurnSwitcher { get; }
        
        public TurnUser AssignStage { get; }
        public TurnUser BuildStage { get; }
        public TurnUser EventStage  { get; }
        public TurnUser CurrentStage => TurnSwitcher.CurrentUser as TurnUser;
        
        public BuildingGame(IGraphMap map,IEntityRegister entityRegister, ISubscriber entityRegisterEvents) 
        {
            Map = map;
            EntityRegister = entityRegister;
            EntityRegisterEvents = entityRegisterEvents;
            
            AssignStage = new TurnUser();
            BuildStage = new TurnUser();
            EventStage = new TurnUser();
            
            TurnSwitcher = new TurnSwitcher(new ITurnUser[] { AssignStage, BuildStage, EventStage });
        }
        
        public void Update()
        {
            TurnSwitcher.Update();
        }
    }
}