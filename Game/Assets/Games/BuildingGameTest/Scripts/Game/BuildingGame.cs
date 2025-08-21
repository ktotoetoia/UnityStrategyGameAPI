using TDS.Entities;
using TDS.Events;
using TDS.Maps;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public class BuildingGame
    {
        public IGraphMap Map { get; }
        public IEventsEntityRegistry EntityRegistry { get; }
        public ITurnSwitcher TurnSwitcher { get; }
        
        public GameStage PlayerStage { get; }
        public GameStage EventStage  { get; }
        public GameStage CurrentStage => TurnSwitcher.CurrentUser as GameStage;
        
        public BuildingGame(IGraphMap map,IEventsEntityRegistry entityRegistry) 
        {
            Map = map;
            EntityRegistry = entityRegistry;
            
            PlayerStage = new GameStage();
            EventStage = new GameStage();
            
            TurnSwitcher = new TurnSwitcher(new ITurnUser[] { PlayerStage, EventStage });
        }
        
        public void Update()
        {
            TurnSwitcher.Update();
        }
    }
}