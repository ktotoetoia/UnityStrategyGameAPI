using System;
using System.Linq;
using TDS.Maps;
using UnityEngine;

namespace TDS.SelectionSystem
{
    public class TerrainSelector : ISelector
    {
        public event Action OnSelected;
        
        private ISelection<ITerrain> _selection;
        public IMap Map { get; set; }
        public ISelection<object> Selection => _selection;
        public Func<ITerrain,bool> Allow { get; protected set; }
        
        public TerrainSelector(IMap map)
        {
            Map = map;
            _selection = new Selection<ITerrain>();
        }

        public void UpdateSelection(Vector3 position)
        {
            _selection.Deselect();
            
            _selection = GetSelection<ITerrain>(position);
            
            OnSelected?.Invoke();
        }

        public ISelection<T> GetSelection<T>(Vector3 position) where T : class
        {
            ITerrain terrain = Map.GetTerrainsAt(position).FirstOrDefault(x => x is T);
            Selection<T> selection = new Selection<T>();

            if (terrain != null && (Allow == null || Allow(terrain)))
            {
                selection = new Selection<T>(terrain as T);
            }

            return selection;
        }

        public ISelection<T> SelectionOfType<T>()where T : class
        {
            return new Selection<T>(_selection.Selected.OfType<T>());
        }

        public void UpdateSelection(Bounds bounds)
        {
            throw new NotImplementedException();
        }

        public ISelection<T> GetSelection<T>(Bounds bounds)where T : class
        {
            throw new NotImplementedException();
        }
    }
}