using System;
using System.Linq;
using TDS.Worlds;
using UnityEngine;

namespace TDS.SelectionSystem
{
    public class TerrainSelector : ISelector
    {
        public event Action OnSelected;
        
        public IMap Map { get; set; }
        public ISelection Selection { get; private set; }
        public Func<ITerrain,bool> Allow { get; protected set; }
        
        public TerrainSelector(IMap map)
        {
            Map = map;
            Selection = new Selection();
        }

        public void UpdateSelection(Vector3 position)
        {
            ITerrain terrain = Map.GetTerrainsAt(position).FirstOrDefault();
            
            Selection.Deselect();

            if (terrain != null&& (Allow== null || Allow(terrain)))
            {
                Selection = new Selection(new SelectableWrapper(terrain));
            }
            else
            {
                Selection = new Selection();
            }
            
            OnSelected?.Invoke();
        }

        public void UpdateSelection(Bounds bounds)
        {
            throw new NotImplementedException();
        }
    }
}