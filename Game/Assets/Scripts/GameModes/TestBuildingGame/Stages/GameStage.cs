using TDS.Commands;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public class GameStage : TurnUser, IGameStage
    {
        public ICommandHandler CommandHandler { get; set; }
        public IInputHandler InputHandler { get; set; }
        
        public GameStage(ICommandHandler commandHandler, IInputHandler inputHandler)
        {
            CommandHandler = commandHandler;
            InputHandler = inputHandler;
        }

        public GameStage()
        {
            
        }

        public void Update()
        {
            InputHandler.HandleInput(CommandHandler);
        }
    }
}