using UnityEngine;

namespace TDS.SelectionSystem
{
    public interface ISelector : IHaveSelection
    {
        event System.Action OnSelected;

        void UpdateSelection(Vector3 position);
        void UpdateSelection(Bounds bounds);
    }
}