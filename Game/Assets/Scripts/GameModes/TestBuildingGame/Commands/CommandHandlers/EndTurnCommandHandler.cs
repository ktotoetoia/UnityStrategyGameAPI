using TDS.Commands;

namespace BuildingsTestGame
{
    public class EndTurnCommandHandler : ICommandHandler
    {
        public bool CanDoCommand(ICommand command)
        {
            return command is EndTurnCommand;
        }

        public void DoCommand(ICommand command)
        {
            if (CanDoCommand(command))
            {
                (command as EndTurnCommand).TurnUser.EndTurn();
            }
        }
    }
}