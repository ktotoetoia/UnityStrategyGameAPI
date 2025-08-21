using System;
using TDS.Entities;

namespace TDS.Components
{
    public class Component : IComponent
    {
        private IEntity _entity;

        public IEntity Entity
        {
            get
            {
                ThrowExceptionIfDestroyed();
                return _entity;
            }
            
            private set => _entity = value;
        }
        public bool IsDestroyed { get; protected set; }
        
        public virtual void Destroy()
        {
            if (IsDestroyed)
            {
                throw new Exception("Component has already been destroyed.");
            }
            
            Entity = null;
            IsDestroyed = true;
        }

        public virtual void Init(IEntity entity)
        {
            if (Entity != null)
            {
                throw new Exception("Component has already been initialized.");
            }
            
            Entity = entity;
        }

        public virtual void OnRegistered()
        {
            
        }

        protected void ThrowExceptionIfDestroyed()
        {
            if (IsDestroyed)
            {
                throw new Exception("Component has been destroyed.");
            }
        }
    }
}