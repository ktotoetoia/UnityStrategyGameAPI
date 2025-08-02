using System.Collections.Generic;
using System.Linq;
using TDS.Entities;
using UnityEngine;

namespace TDS.SelectionSystem
{
    public class EntitySelectionProvider : ISelectionProvider
    {
        public float Range { get; set; } = 0.2f;
        public IEntityRegister EntityRegister { get; set; }

        public EntitySelectionProvider(IEntityRegister entityRegister)
        {
            EntityRegister = entityRegister;
        }
        
        public ISelection<T> SelectAt<T>(Vector3 position) where T : class
        {            
            IEntity ent = null;
            float distance = Range;
            
            foreach (IEntity entity in EntityRegister.Entities.Where(x=> x is T))
            {
                float lDistance = Vector3.Distance(entity.Transform.Position, position);

                if (lDistance <= distance)
                {
                    ent = entity;
                    distance = lDistance;
                }
            }
            return new Selection<T>(ent as T);
        }

        public ISelection<T> SelectWithin<T>(Bounds bounds) where T : class
        {            
            List<T> selected = EntityRegister.Entities
                .Where(x => x is T && bounds.Contains(x.Transform.Position)).OfType<T>().ToList();

            return new Selection<T>(selected);
        }
    }
}