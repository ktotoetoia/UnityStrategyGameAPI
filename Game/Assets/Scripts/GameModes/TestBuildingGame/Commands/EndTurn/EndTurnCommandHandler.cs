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
            if (command is EndTurnCommand com)
            {
                com.TurnUser.EndTurn();
                com.Finish(CommandStatus.Success);
            }
        }
    }
}