using System.Collections.Generic;
using TDS.Components;

namespace TDS.Entities
{
    public class Entity : IEntity
    {
        protected List<IComponent> _components = new();

        public string Name { get; set; }
        public ITransformComponent Transform { get; set; }
        public IEnumerable<IComponent> Components => _components;
        public bool IsDestroyed { get; private set; }

        public Entity()
        {
            Transform = new TransformComponent();
            AddComponent(Transform);
        }

        public void AddComponent(IComponent component)
        {
            ThrowExceptionIfDestroyed();
            _components.Add(component);
            component.Init(this);
        }

        public void RemoveComponent(IComponent component)
        {
            ThrowExceptionIfDestroyed();
            _components.Remove(component);
            component.Destroy();
        }


        public void Destroy()
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
                throw new System.Exception("Entity has already been destroyed.");
            }
        }
    }
}