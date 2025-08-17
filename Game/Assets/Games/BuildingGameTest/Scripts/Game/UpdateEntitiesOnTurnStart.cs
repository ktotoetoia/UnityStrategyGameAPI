using System.Linq;
using TDS.Entities;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public class UpdateEntitiesOnTurnStart
    {
        private readonly TurnUser _turnUser;
        private readonly IEntityRegistry _entityRegistry;
        
        public UpdateEntitiesOnTurnStart(TurnUser turnUser, IEntityRegistry entityRegistry)
        {
            _entityRegistry = entityRegistry;
            _turnUser = turnUser;
            turnUser.OnTurnStart += Iterate;
        }

        private void Iterate()
        {
            foreach (IEntity entity in _entityRegistry)
            {
                (entity as ITurnObject)?.OnTurnStart();

                foreach (ITurnObject turnComponent in entity.Components.OfType<ITurnObject>())
                {
                    turnComponent.OnTurnStart();
                }
            }
        }

        public void Subscribe()
        {
            _turnUser.OnTurnStart += Iterate;
        }

        public void Unsubscribe()
        {
            _turnUser.OnTurnStart -= Iterate;
        }
    }
}