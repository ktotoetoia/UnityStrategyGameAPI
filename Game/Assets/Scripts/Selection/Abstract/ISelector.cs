using UnityEngine;

namespace TDS.SelectionSystem
{
    public interface ISelector
    {
        event System.Action OnSelected;
        ISelection Selection { get; }

        void UpdateSelection(Vector3 position);
        void UpdateSelection(Bounds bounds);
    }
}