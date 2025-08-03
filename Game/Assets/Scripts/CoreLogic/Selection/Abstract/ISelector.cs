using UnityEngine;

namespace TDS.SelectionSystem
{
    public interface ISelector : IHaveSelection
    {
        ISelectionProvider SelectionProvider { get; }
        void UpdateSelectionAt(Vector3 position);
        void UpdateSelectionWithin(Bounds bounds);
    }
}