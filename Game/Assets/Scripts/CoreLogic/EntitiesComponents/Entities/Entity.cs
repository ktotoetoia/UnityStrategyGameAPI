using System;
using System.Collections.Generic;
using TDS.Components;

namespace TDS.Entities
{
    public class Entity : IEntity
    {
        private List<IComponent> _components = new();
        private IEntityRegister _entityRegister;
        
        public string Name { get; set; }
        public ITransformComponent Transform { get;  }
        public IEnumerable<IComponent> Components => _components;
        public bool IsDestroyed { get; private set; }
        
        public IEntityRegister EntityRegister
        {
            get
            {
                return _entityRegister;
            }
            set
            {
                ThrowExceptionIfDestroyed();
                if (_entityRegister != null && _entityRegister.Contains(this))
                {
                    throw new InvalidOperationException("This entity cannot be contained in more than one entity register");
                }

                if (value != null && !value.Contains(this))
                {
                    throw new InvalidOperationException("Must add entity to a register collection before setting it");
                }
                
                _entityRegister = value;
            }
        }

        public Entity() : this(new TransformComponent())
        {
            
        }

        public Entity(ITransformComponent transformComponent)
        {
            Transform = transformComponent;
            AddComponent(Transform);
        }

        public void AddComponent(IComponent component)
        {
            ThrowExceptionIfDestroyed();
            component.Init(this);
            _components.Add(component);
        }

        public void RemoveComponent(IComponent component)
        {
            ThrowExceptionIfDestroyed();
            _components.Remove(component);
            component.Destroy();
        }
        
        public virtual void Destroy()
        {
            ThrowExceptionIfDestroyed();
            
            foreach (IComponent component in _components)
            {
                component.Destroy();
            }
            
            _components.Clear();
            IsDestroyed = true;
        }

        protected void ThrowExceptionIfDestroyed()
        {
            if (IsDestroyed)
            {
                throw new Exception("Entity has already been destroyed.");
            }
        }
    }
}