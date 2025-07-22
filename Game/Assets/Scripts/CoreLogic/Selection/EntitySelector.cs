using System;
using System.Collections.Generic;
using System.Linq;
using TDS.Entities;
using TDS.Worlds;
using UnityEngine;

namespace TDS.SelectionSystem
{
    public class EntitySelector : ISelector
    {
        public event Action OnSelected;
        private ISelection<IEntity> _selection;
        
        public float Range { get; set; } = 0.2f;
        public IWorld World { get; set; }
        public ISelection<object> Selection => _selection;
        
        public EntitySelector(IWorld world)
        {
            World = world;
            _selection = new Selection<IEntity>();
        }

        public void UpdateSelection(Vector3 position)
        {
            _selection.Deselect();
            _selection = GetSelection<IEntity>(position);
            OnSelected?.Invoke();
        }

        public void UpdateSelection(Bounds bounds)
        {
            _selection.Deselect();
            _selection = GetSelection<IEntity>(bounds);
            OnSelected?.Invoke();
        }

        public ISelection<T> GetSelection<T>(Vector3 position) where T : class
        {            
            IEntity ent = null;
            float distance = Range;
            
            foreach (IEntity entity in World.EntityRegister.Entities.Where(x=> x is T))
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

        public ISelection<T> GetSelection<T>(Bounds bounds) where T : class
        {            
            List<T> selected = World.EntityRegister.Entities
                .Where(x => x is T && bounds.Contains(x.Transform.Position)).OfType<T>().ToList();

            return new Selection<T>(selected);
        }

        public ISelection<T> SelectionOfType<T>() where T : class
        {
            return new Selection<T>(_selection.Selected.OfType<T>());
        }
    }
}