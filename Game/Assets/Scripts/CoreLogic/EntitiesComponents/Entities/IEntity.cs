using System.Collections.Generic;
using TDS.Components;

namespace TDS.Entities
{
    public interface IEntity : IHaveName, IDestroyable, IHaveEntityRegister
    {
        public ITransformComponent Transform { get; }
        public IEnumerable<IComponent> Components { get; }

        void AddComponent(IComponent component);
        void RemoveComponent(IComponent component);
    }
}