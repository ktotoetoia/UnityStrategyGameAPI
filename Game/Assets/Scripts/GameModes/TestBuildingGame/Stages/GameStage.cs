using TDS;
using TDS.Commands;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public class GameStage : TurnUser, IGameStage
    {
        public ICommandListener CommandListener { get; set; }
        public IInputHandler InputHandler { get; set; }

        public GameStage(ICommandListener commandListener, IInputHandler inputHandler)
        {
            CommandListener = commandListener;
            InputHandler = inputHandler;
        }

        public GameStage()
        {
            
        }

        public void Update()
        {
            InputHandler.HandleInput(CommandListener);
        }
    }
}