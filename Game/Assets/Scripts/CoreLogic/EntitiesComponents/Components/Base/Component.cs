using TDS.Entities;

namespace TDS.Components
{
    public class Component : IComponent
    {
        public IEntity Entity { get; protected set; }
        public bool IsDestroyed { get; private set; }

        public virtual void Destroy()
        {
            Entity = null;
            IsDestroyed = true;
        }

        public virtual void Init(IEntity entity)
        {
            Entity = entity;
        }
    }
}