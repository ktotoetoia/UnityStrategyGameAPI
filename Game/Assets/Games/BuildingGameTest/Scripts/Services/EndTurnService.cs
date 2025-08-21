using System;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public class EndTurnService : IGameService
    {
        private ITurnUserManual _turnUser;
        private Func<bool> _canUse;
        public bool CanUse => _canUse();
        

        public EndTurnService(Func<bool> canUse, ITurnUserManual turnUser)
        {
            _canUse = canUse;
            _turnUser = turnUser;
        }

        public void EndTurn()
        {
            if (!CanUse)
            {
                throw new Exception("Can't use EndTurnService");
            }
            
            _turnUser.EndTurn();
        }
    }
}