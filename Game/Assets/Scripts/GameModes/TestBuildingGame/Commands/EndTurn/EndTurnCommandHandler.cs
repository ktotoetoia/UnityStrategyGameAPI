using TDS.Commands;

namespace BuildingsTestGame
{
    public class EndTurnCommandHandler : IEventHandler<EndTurnCommand>
    {
        public void Handle(EndTurnCommand evt)
        {                
            evt.TurnUser.EndTurn();
        }
    }
}