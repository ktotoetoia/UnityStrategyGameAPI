using TDS.Commands;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public class GameStage : TurnUser, IGameStage
    {
        public IInputHandler InputHandler { get; set; }
        public IEventBus EventBus { get; set; }
        
        public GameStage(IEventBus eventBus, IInputHandler inputHandler)
        {
            EventBus = eventBus;
            InputHandler = inputHandler;
        }

        public GameStage()
        {
            
        }

        public void Update()
        {
            InputHandler.HandleInput(EventBus);
        }
    }
}