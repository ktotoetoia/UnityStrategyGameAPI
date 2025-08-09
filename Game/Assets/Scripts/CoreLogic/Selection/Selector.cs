using TDS.Entities;
using UnityEngine;

namespace TDS.SelectionSystem
{
    public class Selector : ISelector
    {  
        private readonly ISelectionProvider _selectionProvider;
        private ISelection<object> _selection;
        
        public ISelectionProvider SelectionProvider => _selectionProvider;
        
        public Selector(ISelectionProvider selectionProvider)
        {
            _selectionProvider = selectionProvider;
            _selection = new Selection<IEntity>();
        }

        public void UpdateSelectionAt(Vector3 position)
        {
            _selection = _selectionProvider.SelectAt<object>(position);
        }

        public void UpdateSelectionWithin(Bounds bounds)
        {
            _selection = _selectionProvider.SelectWithin<object>(bounds);
        }
        
        public ISelection<T> GetSelection<T>() where T : class
        {
            return _selection.OfType<T>();
        }
    }
}