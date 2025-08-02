using UnityEngine;

namespace TDS.SelectionSystem
{
    public interface ISelectionController : IHaveSelection
    {
        event System.Action OnSelected;
        ISelectionProvider SelectionProvider { get; }
        void UpdateSelectionAt(Vector3 position);
        void UpdateSelectionWithin(Bounds bounds);
    }
}