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
        
        public float Range { get; set; } = 0.2f;
        public IWorld World { get; set; }
        public ISelection Selection { get; private set; }

        public EntitySelector(IWorld world)
        {
            World = world;
            Selection = new Selection();
        }

        public void UpdateSelection(Vector3 position)
        {
            IEntity ent = null;
            var distance = Range;

            foreach (var entity in World.EntityRegister.Entities)
            {
                var lDistance = Vector3.Distance(entity.Transform.Position, position);

                if (lDistance <= distance)
                {
                    ent = entity;
                    distance = lDistance;
                }
            }

            Selection.Deselect();
            Selection = new Selection(new SelectableWrapper(ent));
            OnSelected?.Invoke();
        }

        public void UpdateSelection(Bounds bounds)
        {
            IEnumerable<ISelectable> selected = World.EntityRegister.Entities
                .Where(x => bounds.Contains(x.Transform.Position)).Select(x => new SelectableWrapper(x)).ToList();

            Selection.Deselect();
            Selection = new Selection(selected);
        }
    }
}