using TDS.Events;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public class EndTurnCommand : IEvent
    {
        public ITurnUserManual TurnUser { get; }

        public EndTurnCommand(ITurnUserManual TurnUser)
        {
            this.TurnUser = TurnUser;
        }
    }
}