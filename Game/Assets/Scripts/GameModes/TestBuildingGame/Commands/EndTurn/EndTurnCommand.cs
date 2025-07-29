using TDS.Commands;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public class EndTurnCommand : Command
    {
        public ITurnUserManual TurnUser { get; }

        public EndTurnCommand(ITurnUserManual TurnUser)
        {
            this.TurnUser = TurnUser;
        }
    }
}