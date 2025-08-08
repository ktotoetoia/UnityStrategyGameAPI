using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public class GameStage : TurnUser, IGameStage
    {
        public ITurnCommandSequencer CommandSequencer { get; set; }
        
        public GameStage(ITurnCommandSequencer commandSequencer)
        {
            CommandSequencer = commandSequencer;
        }

        protected override void OnStart()
        {
            
        }
    }
}