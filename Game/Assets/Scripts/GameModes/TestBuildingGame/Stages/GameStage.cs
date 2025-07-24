using TDS.Commands;
using TDS.Events;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public class GameStage : TurnUser, IGameStage
    {
        public IInputHandler InputHandler { get; set; }
        public ICommandSequencer CommandSequencer { get; set; }
        
        public GameStage(ICommandSequencer commandSequencer, IInputHandler inputHandler)
        {
            CommandSequencer = commandSequencer;
            InputHandler = inputHandler;
        }

        public GameStage()
        {
            
        }

        public void Update()
        {
            InputHandler.HandleInput(CommandSequencer);
        }
    }
}