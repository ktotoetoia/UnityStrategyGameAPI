using TDS.Commands;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public class EndTurnCommandListener : ICommandListener
    {
        private TurnUser _user;

        public EndTurnCommandListener(TurnUser user)
        {
            _user = user;
        }

        public bool CanDoCommand(ICommand command)
        {
            return command is EndTurnCommand;
        }

        public void DoCommand(ICommand command)
        {
            if (CanDoCommand(command))
            {
                _user.EndTurn();
            }
        }
    }
}