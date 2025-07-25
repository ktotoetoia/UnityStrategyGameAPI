using TDS.Commands;
using TDS.Events;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public class GameStage : TurnUser, IGameStage
    {
        public ICommandSequencer CommandSequencer { get; set; }
        
        public GameStage(ICommandSequencer commandSequencer)
        {
            CommandSequencer = commandSequencer;
        }
    }
}