using System.Linq;
using TDS.Components;

namespace TDS.Entities
{
    public static class EntityExtensions
    {
        public static TComponent GetComponent<TComponent>(this IEntity entity) where TComponent : class, IComponent
        {
            return entity.Components.FirstOrDefault(x => x is TComponent) as TComponent;
        }

        public static bool TryGetComponent<TComponent>(this IEntity entity, out TComponent component) where TComponent : class, IComponent
        {
            component = GetComponent<TComponent>(entity);
            return component != null;
        }
    }
}