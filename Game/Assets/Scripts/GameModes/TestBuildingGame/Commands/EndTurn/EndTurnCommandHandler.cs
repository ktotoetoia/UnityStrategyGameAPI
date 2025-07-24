using TDS.Events;

namespace BuildingsTestGame
{
    public class EndTurnCommandHandler : IEventHandler
    {
        public bool CanHandle(IEvent evt)
        {
            return evt is EndTurnCommand;
        }

        public void Handle(IEvent evt)
        {
            if (evt is not EndTurnCommand command)
            {
                throw new System.ArgumentException();
            }
            
            command.TurnUser.EndTurn();
        }
    }
}