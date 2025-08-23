using System.Collections.Generic;
using System.Linq;
using TDS.Components;

namespace TDS.Entities
{
    public static class EntityExtensions
    {
        public static TComponent GetComponent<TComponent>(this IEntity entity) 
            where TComponent : class
        {
            return entity.Components.FirstOrDefault(x => x is TComponent a) as TComponent;
        }

        public static bool TryGetComponent<TComponent>(this IEntity entity, out TComponent component) 
            where TComponent : class
        {
            component = GetComponent<TComponent>(entity);
            return component != null;
        }

        public static IEnumerable<(IEntity, T1)> WithComponent<T1>(this IEnumerable<IEntity> entities)
            where T1 : class
        {
            foreach (var entity in entities)
            {
                if (entity.TryGetComponent(out T1 t1))
                {
                    yield return (entity, t1);
                }
            }
        }

        public static IEnumerable<(IEntity, T1, T2)> WithComponents<T1, T2>(this IEnumerable<IEntity> entities)
            where T1 : class
            where T2 : class
        {
            foreach (var entity in entities)
            {
                if (entity.TryGetComponent(out T1 t1) &&
                    entity.TryGetComponent(out T2 t2))
                {
                    yield return (entity, t1, t2);
                }
            }
        }

        public static IEnumerable<(IEntity, T1, T2, T3)> WithComponents<T1, T2, T3>(this IEnumerable<IEntity> entities)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            foreach (var entity in entities)
            {
                if (entity.TryGetComponent(out T1 t1) &&
                    entity.TryGetComponent(out T2 t2) &&
                    entity.TryGetComponent(out T3 t3))
                {
                    yield return (entity, t1, t2, t3);
                }
            }
        }
    }
}