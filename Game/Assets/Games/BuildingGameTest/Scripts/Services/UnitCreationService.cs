using System;

namespace BuildingsTestGame
{
    public class UnitCreationService : IGameService
    {
        private readonly Func<bool> _canUse;
        public bool CanUse => _canUse();

        public UnitCreationService(Func<bool> canUse)
        {
            _canUse = canUse;
        }

        public void CreateUnit(IEntityCreationComponent component, IEntityInfo entityInfo)
        {
            if (!CanUse)
            {
                throw new Exception("Can't create unit");
            }
            
            component.AddToQueue(entityInfo);
        }
    }
}