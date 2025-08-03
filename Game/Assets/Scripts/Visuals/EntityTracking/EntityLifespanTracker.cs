using System.Collections.Generic;
using TDS.Entities;
using TDS.Events;
using TDS.Handlers;
using UnityEngine;

namespace TDS
{
    public class EntityLifespanTracker : MonoBehaviour
    {
        private List<IEntityObserver>  _observers = new();
        private IEventSubscriber _entityRegisterEvents;

        public IEventSubscriber EntityRegisterEvents
        {
            get
            {
                return _entityRegisterEvents;
            }
            set
            {
                _entityRegisterEvents  = value;
                _entityRegisterEvents.Subscribe(new ActionHandler<EntityAddedEvent>(x => Add(x.Value)));
                _entityRegisterEvents.Subscribe(new ActionHandler<EntityRemovedEvent>(x => Remove(x.Value)));
            }
        }

        private void Awake()
        {
            GetComponents(_observers);
        }

        private void Add(IEntity entity)
        {
            foreach (IEntityObserver observer in _observers)
            {
                observer.Add(entity);
            }
        }

        private void Remove(IEntity entity)
        {
            foreach (IEntityObserver observer in _observers)
            {
                observer.Remove(entity);
            }
        }
    }
}