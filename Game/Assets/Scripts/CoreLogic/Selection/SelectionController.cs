using System;
using System.Linq;
using TDS.Entities;
using UnityEngine;

namespace TDS.SelectionSystem
{
    public class SelectionController : ISelectionController
    {  
        private readonly ISelectionProvider _selectionProvider;
        private ISelection<object> _selection;
        
        public ISelectionProvider SelectionProvider => _selectionProvider;
        public event Action OnSelected;
        
        public SelectionController(ISelectionProvider selectionProvider)
        {
            _selectionProvider = selectionProvider;
            _selection = new Selection<IEntity>();
        }

        public void UpdateSelectionAt(Vector3 position)
        {
            _selection = _selectionProvider.SelectAt<object>(position);
            OnSelected?.Invoke();
        }

        public void UpdateSelectionWithin(Bounds bounds)
        {
            _selection = _selectionProvider.SelectWithin<object>(bounds);
            OnSelected?.Invoke();
        }
        
        public ISelection<T> GetSelection<T>() where T : class
        {
            return new Selection<T>(_selection.Selected.OfType<T>());
        }
    }
}