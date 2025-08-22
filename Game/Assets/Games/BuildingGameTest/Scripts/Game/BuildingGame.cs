using TDS.Entities;
using TDS.Factions;
using TDS.Maps;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public class BuildingGame
    {
        public IGraphMap Map { get; }
        public IEventsEntityRegistry EntityRegistry { get; }
        public ITurnSwitcher TurnSwitcher { get; }
        public IFactionsManager  FactionsManager { get; }
        
        public FactionTurnUser PlayerStage { get; }
        public FactionTurnUser EnemyStage  { get; }
        public FactionTurnUser CurrentStage => TurnSwitcher.CurrentUser as FactionTurnUser;
        
        public BuildingGame(IGraphMap map,IEventsEntityRegistry entityRegistry) 
        {
            Map = map;
            EntityRegistry = entityRegistry;
            FactionsManager = new FactionsManager();
            
            PlayerStage = new FactionTurnUser();
            EnemyStage = new FactionTurnUser();
            
            TurnSwitcher = new TurnSwitcher(new ITurnUser[] { PlayerStage, EnemyStage });
        }
        
        public void Update()
        {
            TurnSwitcher.Update();
        }
    }
}