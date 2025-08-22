using System;
using System.Collections.Generic;
using System.Linq;
using TDS.Entities;
using TDS.Factions;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public class FactionTurnUser : TurnUser, IGameStage
    {
        public ICollection<IGameService> Services { get; } = new List<IGameService>();
        public IFactionContext FactionContext { get; set; }
        public event Action ActionOnStart;
        public event Action ActionOnEnd;
        
        public FactionTurnUser() : this(() => {},() => {})
        {
            
        }
        
        public FactionTurnUser(Action actionOnStart, Action actionOnEnd)
        {
            ActionOnStart = actionOnStart;
            ActionOnEnd = actionOnEnd;
        }
        
        protected override void OnStart()
        {
            if (FactionContext == null)
            {
                return;
            }
            
            foreach (IEntity entity in FactionContext.Entities)
            {
                (entity as INotifyOnTurnStart)?.OnTurnStart();

                foreach (INotifyOnTurnStart turnComponent in entity.Components.OfType<INotifyOnTurnStart>())
                {
                    turnComponent.OnTurnStart();
                }
            }
            
            ActionOnStart?.Invoke();
        }

        protected override void OnEnd()
        {
            foreach (IEntity entity in FactionContext.Entities)
            {
                (entity as INotifyOnTurnEnd)?.OnTurnEnd();

                foreach (INotifyOnTurnEnd turnComponent in entity.Components.OfType<INotifyOnTurnEnd>())
                {
                    turnComponent.OnTurnEnd();
                }
            }
            
            ActionOnEnd?.Invoke();
        }
        
        public T GetService<T>() where T : IGameService
        {
            return Services.OfType<T>().FirstOrDefault();
        }
    }
}