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
        
        public ITurnUserManual AssignStage { get; }
        public ITurnUserManual BuildStage { get; }
        public ITurnUserManual EventStage  { get; }
        public ITurnUserManual CurrentStage => TurnSwitcher.CurrentUser as ITurnUserManual;
        
        public BuildingGame(IMap map,IEntityRegister entityRegister, ISubscriber entityRegisterEvents) 
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