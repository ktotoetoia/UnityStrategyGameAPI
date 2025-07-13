using TDS.Commands;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public class GameStage : TurnUser, IGameStage
    {
        public ICommandListener CommandListener { get; set; }

        public GameStage(ICommandListener commandListener)
        {
            CommandListener = commandListener;
        }

        public bool CanDoCommand(ICommand command)
        {
            return CommandListener.CanDoCommand(command);
        }

        public void DoCommand(ICommand command)
        {
            CommandListener.DoCommand(command);
        }
    }
}