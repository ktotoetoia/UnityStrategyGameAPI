using TDS.Commands;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public class GameStage : TurnUser, IGameStage
    {
        public ICommandQueue CommandQueue { get; set; }
        public IInputHandler InputHandler { get; set; }
        
        public GameStage(ICommandQueue commandHandler, IInputHandler inputHandler)
        {
            CommandQueue = commandHandler;
            InputHandler = inputHandler;
        }

        public GameStage()
        {
            
        }

        public void Update()
        {
            InputHandler.HandleInput(CommandQueue);
        }
    }
}