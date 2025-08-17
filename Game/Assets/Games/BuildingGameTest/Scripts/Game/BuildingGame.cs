using TDS.Entities;
using TDS.Events;
using TDS.Maps;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public class BuildingGame
    {
        public IGraphMap Map { get; }
        public IEntityRegistry EntityRegistry { get; }
        public ISubscriber EntityRegisterEvents { get; }
        public ITurnSwitcher TurnSwitcher { get; }
        
        public TurnUser AssignStage { get; }
        public TurnUser EventStage  { get; }
        public TurnUser CurrentStage => TurnSwitcher.CurrentUser as TurnUser;
        
        public BuildingGame(IGraphMap map,IEntityRegistry entityRegistry, ISubscriber entityRegisterEvents) 
        {
            Map = map;
            EntityRegistry = entityRegistry;
            EntityRegisterEvents = entityRegisterEvents;
            
            AssignStage = new TurnUser();
            EventStage = new TurnUser();
            
            TurnSwitcher = new TurnSwitcher(new ITurnUser[] { AssignStage, EventStage });
        }
        
        public void Update()
        {
            TurnSwitcher.Update();
        }
    }
}